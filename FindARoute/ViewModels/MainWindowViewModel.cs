// Ignore Spelling: Langs

using Avalonia.Markup.Xaml.Styling;
using FindARoute.Utilities;
using MsBox.Avalonia;
using ReactiveUI;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace FindARoute.ViewModels;
public class MainWindowViewModel : ReactiveObject
{
    public MainWindowViewModel()
    {
        //var service ...

        Home = new HomeViewModel(this);
        SettingsMenu = new SettingsViewModel(this);
        LoadingScreen = new LoadingViewModel();
        NavView = new NavigationViewModel();

        _Settings = new Settings();

        _ContentVM = Home;

        //initialises the lang to english. Will remove once settings
        //properly implemented
        ChangeLang();
    }

    /// <summary>
    /// Global settings object
    /// </summary>
    public Settings _Settings { get; }

    private const int TIMEOUT = 60000;

    #region Navigating Views
    //The view currently being shown
    private ReactiveObject? _ContentVM;

    //used to handle view changes & updates
    public ReactiveObject? ContentVM
    {
        get => _ContentVM;
        set => this.RaiseAndSetIfChanged(ref _ContentVM, value);
    }


    //premade views
    private HomeViewModel Home { get; }
    private SettingsViewModel SettingsMenu { get; }
    private LoadingViewModel LoadingScreen { get; }
    private NavigationViewModel NavView { get; }


    //changes view to LoadingView temporarily
    public void GoNavigate()
    {
        //ContentVM = NavView;

        LoadingScreen.LoadFact();

        NavView.RouteFound += ((object? s, EventArgs e) => GoToNavView());

        Task.Run(() =>
        {
            Timer T = new Timer() { AutoReset = false, Interval = TIMEOUT };
            T.Elapsed += ((object? s, ElapsedEventArgs e) => NavTimeout());
        });

        ContentVM = LoadingScreen;
    }

    private void GoToNavView()
    { ContentVM = NavView; }

    private void NavTimeout()
    {
        ContentVM = Home;

        MessageBoxManager.GetMessageBoxStandard("Timeout", "Sorry, routing timed out").ShowAsync();
    }

    //changes view back to home view
    public void GoHome()
    { ContentVM = Home; }

    //changes view to settings menu
    public void GoSettings()
    { ContentVM = SettingsMenu; }
    #endregion

    #region Localisation
    //CultureCodes for currently supported languages
    public readonly string[] SupportedLanguages =
    { "en-GB", "cy-GB" };

    //Current no of languages supported
    public int MaxLangs
    { get => SupportedLanguages.Length; }

    //Current lang as index of SupportedLanguages
    private int LanguageIndex = -1;

    //Display name of current language
    private static string _Language = "English";
    //Property of ^
    public string Language
    {
        get => _Language;
        set => this.RaiseAndSetIfChanged(ref _Language, value);
    }

    /// <summary>
    /// Cycles to next language
    /// </summary>
    /// <returns>Native name of language & it's code</returns>
    public (string Name, string Code) ChangeLang()
    {//Based on timunie's sample:
     //https://github.com/timunie/Tims.Avalonia.Samples/tree/main/src/LocalizationSample

        //gets code of language now cycling to
        string TargetLang = SupportedLanguages[LanguageIndex.IncOrReset(MaxLangs)];

        //sets the C# culture
        Properties.Resources.Culture = new CultureInfo(TargetLang);

        //gets the native name for display
        Language = Properties.Resources.Culture
                    .NativeName
                    .Split('(')
                    .FirstOrDefault("Lang broke")
                    .Trim();

        //gets the current languages in app's dictionaries
        var Trans = App.Current.Resources.MergedDictionaries
            .OfType<ResourceInclude>()
            .FirstOrDefault
            (X => X.Source?.OriginalString?.Contains("/Langs/") ?? false);

        //if there are languages in dictionary, remove
        if (Trans != null)
        { App.Current.Resources.MergedDictionaries.Remove(Trans); }

        //adds new language to merged dictionaries
        App.Current.Resources.MergedDictionaries.Add(
            new ResourceInclude(new Uri
                ($"avares://FindARoute/Assets/Langs/{TargetLang}.axaml"))
            { Source = new Uri($"avares://FindARoute/Assets/Langs/{TargetLang}.axaml") });

        //returns language name for display
        return (Language, TargetLang);
    }
    #endregion
}

using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media.Imaging;
using FindARoute.Utilities;
using ReactiveUI;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FindARoute.ViewModels;

public class MainViewModel : ViewModelBase
{
    #region Localisation
    public readonly string[] SupportedLanguages =
    { "en-GB", "cy-GB" };
    public int MaxLangs
    { get => SupportedLanguages.Length; }
    private int LanguageIndex = 0;

    private string _Language = "English";
    public string Language
    {
        get => _Language;
        set => this.RaiseAndSetIfChanged(ref _Language, value);
    }

    private Bitmap? _LangFlag = null;

    public Bitmap? LangFlag
    {
        get => _LangFlag;
        set => this.RaiseAndSetIfChanged(ref _LangFlag, value);
    }

    public void ChangeLang(object? sender)
    {//Based on timunie's work:
     //https://github.com/timunie/Tims.Avalonia.Samples/tree/main/src/LocalizationSample

        string TargetLang = SupportedLanguages[LanguageIndex.IncOrReset(MaxLangs)];

        Properties.Resources.Culture = new CultureInfo(TargetLang);

        Language = Properties.Resources.Culture
                    .DisplayName
                    .Split('(')
                    .FirstOrDefault("Lang broke")
                    .Trim();

        var Trans = App.Current.Resources.MergedDictionaries
            .OfType<ResourceInclude>()
            .FirstOrDefault
            (X => X.Source?.OriginalString?.Contains("/Langs/") ?? false);

        if (Trans != null)
        { App.Current.Resources.MergedDictionaries.Remove(Trans); }

        App.Current.Resources.MergedDictionaries.Add(
            new ResourceInclude(new Uri
                ($"avares://FindARoute/Assets/Langs/{TargetLang}.axaml"))
            { Source = new Uri($"avares://FindARoute/Assets/Langs/{TargetLang}.axaml") });

        Task.Run(() =>
        {
            LangFlag = Helpers.LoadFromResource
                (new Uri($"avares://FindARoute/Assets/LangFlags/{TargetLang}.png"));
        });
    }
    #endregion

    private ReactiveObject? _ContentViewModel;

    private NavigationViewModel Navigation => new NavigationViewModel();

    public ReactiveObject? ContentViewModel
    {
        get => _ContentViewModel;
        set => this.RaiseAndSetIfChanged(ref _ContentViewModel, value);
    }

    public MainViewModel()
    {
        LangFlag = Helpers.LoadFromResource
            (new Uri($"avares://FindARoute/Assets/LangFlags/en-GB.png"));

        _ContentViewModel = null;
    }

    public void NavigationView()
    {
        ContentViewModel = Navigation;
    }
}

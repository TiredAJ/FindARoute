// Ignore Spelling: Langs

using Avalonia.Markup.Xaml.Styling;
using FindARoute.Utilities;
using ReactiveUI;
using System;
using System.Globalization;
using System.Linq;

namespace FindARoute.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel()
        {
            //var service ...

            Home = new HomeViewModel(this);
            SettingsMenu = new SettingsViewModel(this);

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

        #region Navigating Views
        //The view currently being shown
        private ReactiveObject? _ContentVM;

        //premade views
        public HomeViewModel Home { get; }
        public SettingsViewModel SettingsMenu { get; }

        //used to handle view changes & updates
        public ReactiveObject? ContentVM
        {
            get => _ContentVM;
            set => this.RaiseAndSetIfChanged(ref _ContentVM, value);
        }

        //changes view to navigation view
        public void GoNavigate()
        { ContentVM = new NavigationViewModel(); }

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
        /// <returns>Display name of language</returns>
        public (string Name, string Code) ChangeLang()
        {//Based on timunie's work:
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
}

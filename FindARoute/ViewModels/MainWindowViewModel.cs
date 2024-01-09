using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media.Imaging;
using FindARoute.Utilities;
using ReactiveUI;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FindARoute.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public MainWindowViewModel()
        {
            //var service ...

            Home = new HomeViewModel(this);

            _ContentVM = Home;

            ChangeLang();
        }

        #region Navigating Views
        private ReactiveObject? _ContentVM;
        public HomeViewModel Home { get; }

        public ReactiveObject? ContentVM
        {
            get => _ContentVM;
            set => this.RaiseAndSetIfChanged(ref _ContentVM, value);
        }

        public void Navigate()
        { ContentVM = new NavigationViewModel(); }

        public void GoHome()
        { ContentVM = Home; }
        #endregion

        #region Localisation
        public readonly string[] SupportedLanguages =
        { "en-GB", "cy-GB" };
        public int MaxLangs
        { get => SupportedLanguages.Length; }
        private int LanguageIndex = -1;

        private static string _Language = "English";
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

        public string ChangeLang()
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

            return Language;
        }
        #endregion
    }
}

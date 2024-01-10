using Avalonia.Media.Imaging;
using FindARoute.Utilities;
using ReactiveUI;

namespace FindARoute.ViewModels
{
    public class HomeViewModel : ReactiveObject
    {
        private string _Language;

        public string Language
        {
            get => _Language;
            set => this.RaiseAndSetIfChanged(ref _Language, value);
        }

        //Image of current language's flag
        private Bitmap? _LangFlag = null;
        //property of ^
        public Bitmap? LangFlag
        {
            get => _LangFlag;
            set => this.RaiseAndSetIfChanged(ref _LangFlag, value);
        }

        public HomeViewModel(MainWindowViewModel _MWVM)
        {
            _Language = "English";

            LangFlag = Helpers.LoadFromResource
                (new System.Uri($"avares://FindARoute/Assets/LangFlags/en-GB.png"));
        }

        public void Command_ChangeLang(object? Sender)
        {
            var MVM = Helpers.GetParentContext(Sender);

            if (MVM != null)
            {
                var Temp = MVM.ChangeLang();

                Language = Temp.Name;

                LangFlag = Helpers.LoadFromResource
                    (new System.Uri($"avares://FindARoute/Assets/LangFlags/{Temp.Code}.png"));
            }
        }

        public void Command_OpenSettings(object? Sender)
        {
            var MVM = Helpers.GetParentContext(Sender);

            if (MVM != null)
            { MVM.GoToSettings(); }
        }
    }
}
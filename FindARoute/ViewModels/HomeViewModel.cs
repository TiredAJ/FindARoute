using Avalonia.Media.Imaging;
using ReactiveUI;

namespace FindARoute.ViewModels
{
    public class HomeViewModel : ReactiveObject
    {
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

        public void ChangeLang()
        { }
    }
}
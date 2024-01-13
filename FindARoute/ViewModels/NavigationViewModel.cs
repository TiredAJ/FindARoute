using ReactiveUI;

namespace FindARoute.ViewModels
{
    public class NavigationViewModel : ReactiveObject
    {
        private string _DirectionStr = string.Empty;

        public string DirectionStr
        {
            get => _DirectionStr;
            set
            { this.RaiseAndSetIfChanged(ref _DirectionStr, value); }
        }

        public NavigationViewModel()
        {

        }

    }
}
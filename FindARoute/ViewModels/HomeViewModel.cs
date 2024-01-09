using Avalonia.Controls;
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

        public HomeViewModel(MainWindowViewModel _MWVM)
        {
            _Language = "English";
        }


        public void Command(object? Sender)
        {
            var V = Sender as UserControl;

            if (V != null && V.Parent != null &&
                (V.Parent.DataContext as MainWindowViewModel) != null)
            { Language = (V.Parent.DataContext as MainWindowViewModel).ChangeLang(); }
        }
    }
}
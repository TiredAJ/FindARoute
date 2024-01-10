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

        public void Command_ChangeLang(object? Sender)
        {
            var MVM = GetParentContext(Sender);

            if (MVM != null)
            { Language = MVM.ChangeLang(); }
        }

        public void Command_OpenSettings(object? Sender)
        {
            var MVM = GetParentContext(Sender);

            if (MVM != null)
            { MVM.GoToSettings(); }
        }

        public MainWindowViewModel? GetParentContext(object? _Sender)
        {
            var View = _Sender as UserControl;

            if (View != null && View.Parent != null &&
                (View.Parent.DataContext as MainWindowViewModel) != null)
            { return View.Parent.DataContext as MainWindowViewModel; }
            else
            { return null; }
        }
    }
}
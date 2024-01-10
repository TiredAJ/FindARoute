using Avalonia.Layout;
using ReactiveUI;

namespace FindARoute.ViewModels
{
    public class SettingsViewModel : ReactiveObject
    {
        public SettingsViewModel(MainWindowViewModel _MWVM)
        {

        }

        private HorizontalAlignment _ControlAlingment = HorizontalAlignment.Right;

        public HorizontalAlignment ControlAlingment
        {
            get => _ControlAlingment;
            set => this.RaiseAndSetIfChanged(ref _ControlAlingment, value);
        }
    }
}
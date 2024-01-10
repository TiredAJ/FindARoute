using Avalonia.Controls.Primitives;
using FindARoute.Utilities;
using ReactiveUI;

namespace FindARoute.ViewModels
{
    public class SettingsViewModel : ReactiveObject
    {
        public SettingsViewModel(MainWindowViewModel _MWVM)
        {

        }

        private string _WiFiStateStr = "Enabled";
        public string WiFiStateStr
        {
            get => _WiFiStateStr;
            set => this.RaiseAndSetIfChanged(ref _WiFiStateStr, value);
        }

        public bool _WiFiState = true;

        public void Command_GoBack(object? Sender)
        {
            var MVM = Helpers.GetParentContext(Sender);

            if (MVM != null)
            { MVM.GoHome(); }
        }

        public void Command_ToggleWiFiPos(ToggleButton _Sender)
        {
            if (_Sender.IsChecked == true)
            { _WiFiState = true; }
            else
            { _WiFiState = false; }
        }
    }
}
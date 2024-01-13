// Ignore Spelling: MWVM

using Avalonia.Controls.Primitives;
using FindARoute.Utilities;
using ReactiveUI;
using Splat;
using System.Runtime.Serialization;

namespace FindARoute.ViewModels
{
    [DataContract]
    public class SettingsViewModel : ReactiveObject, IRoutableViewModel
    {
        #region Settings
        private string _WiFiStateStr = "Enabled";
        [DataMember]
        public string WiFiStateStr
        {
            get => _WiFiStateStr;
            set => this.RaiseAndSetIfChanged(ref _WiFiStateStr, value);
        }

        private bool _WiFiState = true;
        [DataMember]
        public bool WiFiState
        {
            get => _WiFiState;
            set => this.RaiseAndSetIfChanged(ref _WiFiState, value);
        }
        #endregion

        public SettingsViewModel(MainWindowViewModel _MWVM, IScreen? _Screen = null)
        {
            HostScreen = _Screen ?? Locator.Current.GetService<IScreen>();
        }

        #region Command funcs
        public void Command_GoBack(object? Sender)
        {
            var MVM = Helpers.GetParentContext(Sender);

            if (MVM != null)
            { MVM.GoHome(); }
        }

        public void Command_ToggleWiFiPos(ToggleButton _Sender)
        {
            if (_Sender.IsChecked == true)
            { WiFiState = true; }
            else
            { WiFiState = false; }
        }
        #endregion

        public string? UrlPathSegment => "/Settings";

        public IScreen? HostScreen { get; }
    }
}
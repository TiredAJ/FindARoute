using Avalonia.ReactiveUI;
using FindARoute.ViewModels;

namespace FindARoute.Views;

public partial class SettingsView : ReactiveUserControl<SettingsViewModel>
{
    public SettingsView()
    {
        InitializeComponent();
    }
}
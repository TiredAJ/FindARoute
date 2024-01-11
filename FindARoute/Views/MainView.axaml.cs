using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FindARoute.ViewModels;
using ReactiveUI;

namespace FindARoute.Views;

public partial class MainView : ReactiveUserControl<MainWindowViewModel>
{
    public MainView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}
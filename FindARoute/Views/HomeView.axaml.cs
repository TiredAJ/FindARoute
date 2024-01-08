using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FindARoute.ViewModels;
using ReactiveUI;

namespace FindARoute.Views;

public partial class HomeView : ReactiveUserControl<HomeViewModel>
{
    public HomeView()
    {
        this.WhenActivated((Disposable) => { });
        AvaloniaXamlLoader.Load(this);
    }
}
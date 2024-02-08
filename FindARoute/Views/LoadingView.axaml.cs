using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FindARoute.ViewModels;
using ReactiveUI;

namespace FindARoute.Views;

public partial class LoadingView : ReactiveUserControl<LoadingViewModel>
{
    public LoadingView()
    {
        this.WhenActivated((Disposable) => { });
        AvaloniaXamlLoader.Load(this);
    }
}

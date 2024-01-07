using Avalonia.ReactiveUI;
using FindARoute.ViewModels;

namespace FindARoute.Views;

public partial class MainWindow : ReactiveWindow<MainViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.ViewModel = new MainViewModel();
    }
}

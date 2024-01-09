using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using FindARoute.ViewModels;

namespace FindARoute.Views;

public partial class NavigationView : ReactiveUserControl<NavigationViewModel>
{
    public NavigationView()
    {
        InitializeComponent();
    }

    public void btn_Click(object? Sender, RoutedEventArgs e)
    {
        (this.Parent.DataContext as MainWindowViewModel).GoHome();

        //Console.WriteLine(Par.ToString());
    }
}
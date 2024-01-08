using Avalonia.ReactiveUI;
using FindARoute.ViewModels;

namespace FindARoute.Views;

public partial class NavigationView : ReactiveUserControl<NavigationViewModel>
{
    public NavigationView()
    {
        InitializeComponent();
    }
}
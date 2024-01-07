using Avalonia.ReactiveUI;
using FindARoute.ViewModels;

namespace FindARoute.Views
{
    public partial class NavView : ReactiveUserControl<NavigationViewModel>
    {
        public NavView()
        {
            InitializeComponent();
        }
    }
}

using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace FindARoute.ViewModels
{
    public class MainWindowViewModel : ReactiveUserControl<MainWindowViewModel>
    {
        public string Greeting => "Welcome to Avalonia!";

        public MainWindowViewModel()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}

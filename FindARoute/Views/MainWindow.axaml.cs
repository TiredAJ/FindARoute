using Avalonia;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FindARoute.ViewModels;
using ReactiveUI;

namespace FindARoute.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);

#if DEBUG

            var temp = new KeyGesture(Key.F12, KeyModifiers.Alt | KeyModifiers.Control);

            this.AttachDevTools(temp);
#endif
        }
    }
}
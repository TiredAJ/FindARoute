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

        //IMG_BTN_NavigateMe.Loaded += ((Sender, e) =>
        //{
        //    IMG_BTN_NavigateMe.Source = Helpers.LoadFromResource(
        //    new System.Uri($"avares://FindARoute/Assets/Icons/Arrow-Right.png"));
        //});

        //IMG_BTN_LocateMe.Loaded += ((Sender, e) =>
        //{
        //    IMG_BTN_LocateMe.Source = Helpers.LoadFromResource(
        //    new System.Uri($"avares://FindARoute/Assets/LocateMe.png"));
        //});
    }
}
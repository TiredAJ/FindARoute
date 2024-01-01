using Avalonia.Controls;
using Avalonia.Media.Imaging;
using MsBox.Avalonia;
using System.Globalization;
using System.IO;

namespace FindARoute.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        //Debug.WriteLine(Path.GetFullPath(Directory.GetCurrentDirectory() + "/Assets/Logo.png"));

        GenerateImage(Properties.Resources.LogoPng, IMG_Logo);

        GenerateImage(Properties.Resources.LocateMe, IMG_BTN_LocateMe);

        btn_Language.Click += Btn_Language_Click;

        Popup("Language", $"Language:");
    }

    private void Btn_Language_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //https://azuliadesigns.com/c-sharp-tutorials/list-net-culture-country-codes/

        if (Properties.Resources.Culture.Name == "cy-GB")
        { Properties.Resources.Culture = new CultureInfo("en-GB"); }
        else
        { Properties.Resources.Culture = new CultureInfo("cy-GB"); }

        Popup("Language", $"Language now:");
    }

    public void GenerateImage(byte[] _Data, Image _Ctrl)
    {
        using (Stream S = new MemoryStream(_Data))
        { _Ctrl.Source = new Bitmap(S); }
    }

    public static async void Popup(string _Title, string _Content)
    {
        var Pop = MessageBoxManager.GetMessageBoxStandard(_Title, _Content);

        var R = await Pop.ShowAsync();
    }
}

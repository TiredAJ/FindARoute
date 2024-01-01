using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System.Diagnostics;
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

        btn_Lanuage.Click += Btn_Lanuage_Click;

        Debug.WriteLine(Properties.Resources.Culture.DisplayName);
    }

    private void Btn_Lanuage_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (Properties.Resources.Culture.Name == "cy-GB")
        { Properties.Resources.Culture = new CultureInfo("en-GB"); }
        else
        { Properties.Resources.Culture = new CultureInfo("cy-GB"); }
    }

    public void GenerateImage(byte[] _Data, Image _Ctrl)
    {
        using (Stream S = new MemoryStream(_Data))
        { _Ctrl.Source = new Bitmap(S); }
    }
}

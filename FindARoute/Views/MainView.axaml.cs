using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System.Diagnostics;
using System.Drawing;
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
    }

    public void GenerateImage(byte[] _Data, Image _Ctrl)
    {
        using (Stream S = new MemoryStream(_Data))
        { _Ctrl.Source = new Bitmap(S); }
    }
}

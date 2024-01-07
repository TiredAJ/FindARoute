using Avalonia.Controls;
using FindARoute.Utilities;

namespace FindARoute.Views;

public partial class MainView : UserControl
{
    int InitCount = 0;

    public MainView()
    {
        InitializeComponent();

        //Debug.WriteLine(Path.GetFullPath(Directory.GetCurrentDirectory() + "/Assets/Logo.png"));

        //GenerateImage(Properties.Resources.img_Logo, IMG_Logo);

        //GenerateImage(Properties.Resources.img_LocateMe, IMG_BTN_LocateMe);

        //btn_Language.Click += Btn_Language_Click;

        //Popup("Language", $"Language:");

        btn_Language.Loaded += Ctrl_Loaded;
    }

    private void Ctrl_Loaded(object? sender, System.EventArgs e)
    {
        var Temp = TopLevel.GetTopLevel(btn_Language);

        if (Temp != null)
        { Settings.Load(Temp.StorageProvider); }
    }
}

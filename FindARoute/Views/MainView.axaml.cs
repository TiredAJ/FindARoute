using Avalonia.Controls;
using FindARoute.Utilities;

namespace FindARoute.Views;

public partial class MainView : UserControl
{
    int InitCount = 0;

    public MainView()
    {
        InitializeComponent();

        btn_Language.Loaded += Ctrl_Loaded;
    }

    private void Ctrl_Loaded(object? sender, System.EventArgs e)
    {
        var Temp = TopLevel.GetTopLevel(btn_Language);

        if (Temp != null)
        { Settings.Load(Temp.StorageProvider); }
    }
}

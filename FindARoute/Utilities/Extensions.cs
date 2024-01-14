// Ignore Spelling: Inc Popup Dialog

using Avalonia.Controls;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using FindARoute.ViewModels;
using MsBox.Avalonia.Base;
using MsBox.Avalonia.Enums;
using System;
using System.IO;
using System.Threading.Tasks;

using MSM = MsBox.Avalonia.MessageBoxManager;

namespace FindARoute.Utilities
{
    public static class Extensions
    {
        public static int IncOrReset(this ref int _Main, int _Max)
        { return (_Main += 1) % _Max; }

        public static void LoadFromProperties(this Image _PBX, byte[] _Data)
        {
            Task.Run(() =>
            {
                Dispatcher.UIThread.Post(() =>
                {
                    using (Stream S = new MemoryStream(_Data))
                    { _PBX.Source = new Bitmap(S); }
                });
            });
        }

        public static string? GetStr(this ResourceInclude _R, string _Key)
        {
            object? T = null;

            _R.TryGetResource(_Key, null, out T);

            return T?.ToString();
        }
    }

    public class Helpers
    {
        public static Uri DefaultImage =
            new Uri("avares://FindARoute/Assets/Default.png");

        public static Bitmap LoadFromResource(Uri _Resource)
        {
            Uri Resource;

            //checks the uri exists. If it does, it loads it. Else it
            //loads the default
            if (AssetLoader.Exists(_Resource))
            { Resource = _Resource; }
            else
            { Resource = DefaultImage; }

            using (var S = AssetLoader.Open(Resource))
            { return new Bitmap(S); }
        }

        public static void LoadFromProperties(Image _PBX, byte[] _Data)
        {
            Task.Run(() =>
            {
                Dispatcher.UIThread.Post(() =>
                {
                    using (Stream S = new MemoryStream(_Data))
                    { _PBX.Source = new Bitmap(S); }
                });
            });
        }

        public static MainWindowViewModel? GetParentContext(object? _Sender)
        {
            var View = _Sender as UserControl;

            if (View != null && View.Parent != null &&
                (View.Parent.DataContext as MainWindowViewModel) != null)
            { return View.Parent.DataContext as MainWindowViewModel; }
            else
            { return null; }
        }
    }

    public static class Popup
    {
        public static Task ShowBasic(string _Title, string _Content)
        { return MSM.GetMessageBoxStandard(_Title, _Content).ShowAsync(); }

        public static Task<ButtonResult> ShowDialog(IMsBox<ButtonResult> _Comp)
        { return _Comp.ShowAsync(); }
    }
}

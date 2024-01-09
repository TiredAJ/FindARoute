using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
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

        public static async void LoadFromProperties(this Image _PBX, byte[] _Data)
        {
            await Task.Run(() =>
            {
                Dispatcher.UIThread.Post(() =>
                {
                    using (Stream S = new MemoryStream(_Data))
                    { _PBX.Source = new Bitmap(S); }
                });
            });
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

        public static async void LoadFromProperties(Image _PBX, byte[] _Data)
        {
            await Task.Run(() =>
            {
                Dispatcher.UIThread.Post(() =>
                {
                    using (Stream S = new MemoryStream(_Data))
                    { _PBX.Source = new Bitmap(S); }
                });
            });
        }
    }

    public static class Popup
    {
        public static async Task ShowBasic(string _Title, string _Content)
        { await MSM.GetMessageBoxStandard(_Title, _Content).ShowAsync(); }

        public static async Task<ButtonResult> ShowDialog(IMsBox<ButtonResult> _Comp)
        { return await _Comp.ShowAsync(); }
    }
}

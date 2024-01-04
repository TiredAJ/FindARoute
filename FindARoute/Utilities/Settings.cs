using Avalonia.Platform.Storage;
using System.Collections.Generic;

namespace FindARoute.Utilities
{
    public class Settings
    {
        private static Dictionary<string, string> _Settings = new Dictionary<string, string>();

        public static string Get(string _Key)
        {
            if (_Settings.ContainsKey(_Key))
            { return _Settings[_Key]; }
            else
            { return string.Empty; }
        }

        public static void Load(IStorageProvider _ISP)
        {
            if (!_ISP.CanOpen)
            { /*throw new System.Exception("Darn thing won't let me save!");*/ }


        }

        public static void Save(IStorageProvider _ISP)
        {

        }
    }
}

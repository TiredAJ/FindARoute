using Avalonia.Markup.Xaml.Styling;
using FindARoute.Utilities;
using ReactiveUI;
using System.Collections.Generic;
using System.Linq;

namespace FindARoute.ViewModels
{
    public class NavigationViewModel : ReactiveObject
    {
        private Dictionary<string, string> DirComps = new()
        {
            {"ContinueForward", string.Empty },
            {"Until", string.Empty },
            {"Then", string.Empty },
            {"TurnLeft", string.Empty },
            {"TurnRight", string.Empty },
            {"Junction", string.Empty },
            {"ElevationNearby", string.Empty },
            {"Go", string.Empty },
            {"Floors", string.Empty },
            {"Up", string.Empty },
            {"Down", string.Empty },
            {"Destination", string.Empty },
            {"DirHere", string.Empty }
        };

        private string _DirectionStr = string.Empty;

        public string DirectionStr
        {
            get => _DirectionStr;
            set
            { this.RaiseAndSetIfChanged(ref _DirectionStr, value); }
        }

        public NavigationViewModel()
        {
            var R = App.Current.Resources.MergedDictionaries.Last() as ResourceInclude;

            foreach (var Key in DirComps.Keys)
            {
                string? S = R.GetStr($"Local.{Key}");

                if (S == null)
                { throw new System.ArgumentNullException("Str component was null!"); }

                DirComps[Key] = S;
            }

            DirectionStr = DirComps["DirHere"];
        }
    }
}
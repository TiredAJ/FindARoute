using ReactiveUI;
using System;
using System.Collections.Generic;

namespace FindARoute.ViewModels
{
    public class NavigationViewModel : ReactiveObject
    {
        public event EventHandler RouteFound;

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
            //temporarilty removed for other testing

            //var R = App.Current.Resources.MergedDictionaries.Last() as ResourceInclude;

            //foreach (var Key in DirComps.Keys)
            //{
            //    string? S = R.GetStr($"Local.{Key}");

            //    if (S == null)
            //    { throw new System.ArgumentNullException("Str component was null!"); }

            //    DirComps[Key] = S;
            //}

            //DirectionStr = DirComps["DirHere"];
        }

        //temporary
        public void FindRoute()
        {
            //when route found......
            RouteFound?.Invoke(this, new EventArgs());
        }
    }
}
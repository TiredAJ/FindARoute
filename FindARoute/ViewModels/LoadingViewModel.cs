using Avalonia.Platform;
using FindARoute.Utilities;
using Microsoft.Maui.ApplicationModel;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FindARoute.ViewModels;

public class LoadingViewModel : ReactiveObject
{
    private List<(string Fact, string Source, string Link)> Facts = new();

    private string _FactStr = "Foxes are cool :3", _Source = "me", _Link = "";

    public string FactStr
    {
        get => _FactStr;
        set => this.RaiseAndSetIfChanged(ref _FactStr, value);
    }

    public string Source
    {
        get => $"- {_Source}";
        set => this.RaiseAndSetIfChanged(ref _Source, value);
    }

    public string Link
    {
        get => _Link;
        set => this.RaiseAndSetIfChanged(ref _Link, value);
    }

    public LoadingViewModel()
    {
        LoadFromFile();
    }

    private async Task LoadFromFile()
    {
        Uri File = new Uri("avares://FindARoute/Assets/FoxFacts.csv");
        string? Line = "";

        using (StreamReader Reader = new StreamReader(AssetLoader.Open(File)))
        {
            while (!Reader.EndOfStream)
            {
                Line = await Reader.ReadLineAsync();

                if (Line == null)
                { continue; }

                var T = Line.Split("%%");

                if (T[0] == "Fact")
                { continue; }

                Facts.Add((T[0], T[1], T[2]));
            }
        }
    }

    public void LoadFact()
    {
        Random RND = new Random((int)DateTime.Now.Ticks);

        int Val = RND.Next(0, Facts.Count - 1);

        (string Fact, string Source, string Link) F = Facts[Val];

        FactStr = F.Fact;
        Source = F.Source;
        Link = F.Link;
    }

    //thanks to nref -> https://github.com/AvaloniaUI/Avalonia/discussions/6664#discussioncomment-6818812
    public async Task OpenHyperlink() => await Browser.OpenAsync(Link);

    public void GoBack(object? Sender)
    {
        var MVM = Helpers.GetParentContext(Sender);

        if (MVM != null)
        { MVM.GoHome(); }
    }
}
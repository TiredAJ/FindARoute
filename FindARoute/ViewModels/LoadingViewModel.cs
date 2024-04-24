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
    private readonly List<(string Fact, string Source, string Link)> Facts;
    private List<int> AvailableFacts = new();

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
        Facts = LoadFromFile();

        for (int i = 0; i < Facts.Count; i++)
        { AvailableFacts.Add(i); }
    }

    private async Task<List<(string Fact, string Source, string Link)>> LoadFromFileAsync()
    {
        Uri File = new Uri("avares://FindARoute/Assets/FoxFacts.csv");

        return await Task.Run(List<(string Fact, string Source, string Link)> () =>
        {
            string? Line = "";
            List<(string Fact, string Source, string Link)> TempFacts = new();

            using (StreamReader Reader = new StreamReader(AssetLoader.Open(File)))
            {
                while (!Reader.EndOfStream)
                {
                    Line = Reader.ReadLine();

                    if (Line == null)
                    { continue; }
                    else if (Line == "EOF")
                    { break; }

                    var T = Line.Split("%%");

                    if (T[0] == "Fact")
                    { continue; }

                    TempFacts.Add((T[0], T[1], T[2]));
                }
            }

            return TempFacts;
        });
    }

    private List<(string Fact, string Source, string Link)> LoadFromFile()
    {
        Uri File = new Uri("avares://FindARoute/Assets/FoxFacts.csv");
        string? Line = "";

        List<(string Fact, string Source, string Link)> TempFacts = new();

        using (StreamReader Reader = new StreamReader(AssetLoader.Open(File)))
        {
            while (!Reader.EndOfStream)
            {
                Line = Reader.ReadLine();

                if (Line == null)
                { continue; }
                else if (Line == "EOF")
                { break; }

                var T = Line.Split("%%");

                if (T[0] == "Fact")
                { continue; }

                TempFacts.Add((T[0], T[1], T[2]));
            }
        }

        return TempFacts;
    }


    public void LoadFact()
    {
        Random RND = new Random((int)DateTime.Now.Ticks);

        int Val = AvailableFacts[RND.Next(0, AvailableFacts.Count - 1)];

        AvailableFacts.Remove(Val);

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
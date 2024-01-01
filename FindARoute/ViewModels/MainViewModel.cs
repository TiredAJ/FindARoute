namespace FindARoute.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public string Language => Properties.Resources.Culture.DisplayName;

    public bool DestinationCMBX = true;
    public bool OriginCMBX = true;
}

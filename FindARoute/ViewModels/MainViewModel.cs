namespace FindARoute.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public string Language => "English";

    public bool DestinationCMBX = true;
    public bool OriginCMBX = true;
}

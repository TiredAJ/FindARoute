using Avalonia.Platform.Storage;
using System.Collections.Generic;
using System.Diagnostics;

namespace FindARoute.Utilities;

public class Settings
{
    private Dictionary<string, ISettingsProperty> _Settings = new();

    /// <summary>
    /// Retrieves the state of the Settings property at the specified key
    /// </summary>
    /// <typeparam name="T">Type of the setting's state</typeparam>
    /// <param name="_Key">Key of the setting</param>
    /// <returns>The state of the setting</returns>
    public T? Get<T>(string _Key)
    {
        if (_Settings.ContainsKey(_Key))
        {
            if (_Settings[_Key] as SettingsProperty<T> == null)
            { return default; }
            else
            { return (_Settings[_Key] as SettingsProperty<T>).Get(); }
        }
        else
        { return default; }
    }

    /// <summary>
    /// For initialising a setting with a state
    /// </summary>
    /// <typeparam name="T">Type of the state</typeparam>
    /// <param name="_Key">Key for the setting</param>
    /// <param name="_State">The state</param>
    /// <returns>True if successful, false otherwise</returns>
    public bool Set<T>(string _Key, T _State)
    {
        var S = new SettingsProperty<T>(_Key, _State);

        return Set(_Key, S, false);
    }

    /// <summary>
    /// Allows the assignment of settings from a state
    /// </summary>
    /// <typeparam name="T">Type of the state</typeparam>
    /// <param name="_Key">Key of the setting</param>
    /// <param name="_State">The state</param>
    /// <param name="_Override">Whether to override existing setting</param>
    /// <returns>True if assigned, false otherwise</returns>
    public bool Set<T>(string _Key, T _State, bool _Override)
    {
        var S = new SettingsProperty<T>(_Key, _State);

        return Set(_Key, S, _Override);
    }

    /// <summary>
    /// For initialising a setting with a settings property (SP)
    /// </summary>
    /// <typeparam name="T">Type of the SP's state</typeparam>
    /// <param name="_Key">Key of the setting</param>
    /// <param name="_Value">The SP to initialise with</param>
    /// <returns>True if successful, false otherwise</returns>
    public bool Set<T>(string _Key, SettingsProperty<T> _Value)
    { return Set(_Key, _Value, false); }

    /// <summary>
    /// For assigning a setting with a settings property (SP)
    /// </summary>
    /// <typeparam name="T">Type of the SP's state</typeparam>
    /// <param name="_Key">Key of the setting</param>
    /// <param name="_Value">The SP to assign</param>
    /// <param name="_Override">Whether to override existing setting</param>
    /// <returns>True if assigned, false otherwise</returns>
    public bool Set<T>(string _Key, SettingsProperty<T> _Value, bool _Override)
    {
        if (_Settings.ContainsKey(_Key) && !_Override)
        { return false; }
        else if (_Settings.ContainsKey(_Key) && _Override)
        { _Settings[_Key] = _Value; return true; }
        else
        { return _Settings.TryAdd(_Key, _Value); }
    }

    /// <summary>
    /// Loads settings from file
    /// </summary>
    public void Load(IStorageProvider _ISP)
    {
        if (!_ISP.CanOpen)
        {
            /*throw new System.Exception("Darn thing won't let me save!");*/
            Debug.WriteLine("Darn thing won't let me save!");
        }
    }

    /// <summary>
    /// Saves settings to file
    /// </summary>
    public void Save(IStorageProvider _ISP)
    {

    }
}

public interface ISettingsProperty { }

public class SettingsProperty<T> : ISettingsProperty
{
    private T? State = default;

    public string Name { get; } = "Default";

    public SettingsProperty(string _Name, T _State)
    {
        State = _State;
        Name = _Name;
    }

    public T? Get() => State;

    /// <summary>
    /// Sets the value if it's unassigned.
    /// </summary>
    /// <param name="_NewState">New state to set</param>
    /// <returns>True if state was changed, false otherwise</returns>
    public bool Set(T _NewState)
    {
        if (State == null)
        {
            State = _NewState;
            return true;
        }
        else
        { return false; }
    }

    /// <summary>
    /// Sets the value with optional override.
    /// </summary>
    /// <param name="_NewState">New state to set</param>
    /// <param name="Override">Whether to override if state is already set</param>
    /// <returns>True if state was changed, false otherwise</returns>
    public bool Set(T _NewState, bool Override)
    {
        if (State == null || Override)
        {
            State = _NewState;
            return true;
        }
        else
        { return false; }
    }
}

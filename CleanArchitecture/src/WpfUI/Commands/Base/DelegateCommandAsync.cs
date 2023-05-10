namespace WpfUI.Commands.Base;
/// <summary>
/// Delegate async command that handles given action when executed
/// Also requires an on exception action to be passed in
/// </summary>
public class DelegateCommandAsync : CommandBaseAsync
{
    private readonly Func<Task> _callback;

    public DelegateCommandAsync(Func<Task> callback, Action<Exception> onException) : base(onException)
    {
        _callback = callback;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        await _callback();
    }
}

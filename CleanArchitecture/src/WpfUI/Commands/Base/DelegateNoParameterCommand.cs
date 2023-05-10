namespace WpfUI.Commands.Base;
/// <summary>
/// Delegate command that handles given action when executed
/// Has no parameters to pass
/// </summary>
public class DelegateNoParameterCommand : ICommand
{
    private readonly Action _execute;

    public DelegateNoParameterCommand(Action execute)
    {
        _execute = execute;
    }


    public bool CanExecute(object? parameter = null)
    {
        return true;
    }

    public void Execute(object? parameter = null)
    {
        _execute();
    }

    public event EventHandler? CanExecuteChanged;
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

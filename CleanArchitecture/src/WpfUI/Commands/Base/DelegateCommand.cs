namespace WpfUI.Commands.Base;
/// <summary>
/// Delegate command that handles given action when executed
/// </summary>
/// <typeparam name="T">The parameter type to pass into delegate</typeparam>
public class DelegateCommand<T> : ICommand
{
    private readonly Predicate<T>? _canExecute;
    private readonly Action<T> _execute;

    public DelegateCommand(Action<T> execute)
     : this(execute, null)
    {
    }

    public DelegateCommand(Action<T> execute, Predicate<T>? canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        if (_canExecute == null) return true;
        if (parameter == null) return true;

        return _canExecute((T)parameter);
    }

    public void Execute(object? parameter)
    {
        if (parameter == null) return;
        _execute((T)parameter);
    }

    public event EventHandler? CanExecuteChanged;
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

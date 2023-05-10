namespace WpfUI.Commands.Base;
/// <summary>
/// Base class for WPF asynchronous commands
/// </summary>
public abstract class CommandBaseAsync : ICommand
{
    private bool _isExecuting;
    private readonly Action<Exception> _onException;

    protected CommandBaseAsync(Action<Exception> onException)
    {
        _onException = onException;
    }

    public bool IsExecuting
    {
        get => _isExecuting;
        set
        {
            _isExecuting = value;
            OnCanExecuteChanged();
        }
    }

    public event EventHandler? CanExecuteChanged;

    public virtual bool CanExecute(object? parameter = null)
    {
        return !IsExecuting;
    }

    public async void Execute(object? parameter = null)
    {
        IsExecuting = true;
        try
        {
            await ExecuteAsync(parameter);
        }
        catch (Exception ex)
        {
            _onException?.Invoke(ex);
        }
        IsExecuting = false;
    }

    protected void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, new EventArgs());
    }

    public abstract Task ExecuteAsync(object? parameter);
}

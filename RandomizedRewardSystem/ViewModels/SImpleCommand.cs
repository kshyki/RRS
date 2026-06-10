using System;
using System.Windows.Input;

// used to connect UI actions (buttons) to ViewModel logic without parameters
public class SimpleCommand : ICommand
{
    private readonly Action _execute; // action to execute when command is called 

    public SimpleCommand(Action execute)
    {
        _execute = execute;
    }

    public event EventHandler? CanExecuteChanged; // event required by ICommand for UI re-evaluation of command state, but here it is not used

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter) // executes the assigned action
    {
        _execute();
    }
}
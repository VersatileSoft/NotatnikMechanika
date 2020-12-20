using System;
using System.Windows.Input;

namespace MvvmPackage.Core.Commands
{

    /// <summary>
    /// Generic Implementation of ICommand
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T> : Command
    {
        /// <summary>
        /// Command that takes an action to execute
        /// </summary>
        /// <param name="execute">The action to execute of type T</param>
        public Command(Action<T> execute)
            : base(o =>
            {
                if (CommandUtils.IsValidCommandParameter<T>(o))
                {
                    execute((T)o);
                }
            })
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
        }

        /// <summary>
        /// Command that takes an action to execute
        /// </summary>
        /// <param name="execute">The action to execute of type T</param>
        /// <param name="canExecute">Function to call to determine if it can be executed.</param>
        public Command(Action<T> execute, Func<T, bool> canExecute)
            : base(o =>
            {
                if (CommandUtils.IsValidCommandParameter<T>(o))
                {
                    execute((T)o);
                }
            }, o => CommandUtils.IsValidCommandParameter<T>(o) && canExecute((T)o))
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException(nameof(canExecute));
            }
        }
    }

    /// <summary>
    /// Implementation of ICommand
    /// </summary>
    public class Command : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;
        private readonly WeakEventManager _weakEventManager = new WeakEventManager();

        /// <summary>
        /// Command that takes an action to execute.
        /// </summary>
        /// <param name="execute">Action to execute.</param>
        protected Command(Action<object> execute)
        {
            this._execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        /// <summary>
        /// Command that takes an action to execute.
        /// </summary>
        /// <param name="execute">Action to execute.</param>
        public Command(Action execute) : this(o => execute())
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
        }

        /// <summary>
        /// Command that takes an action to execute.
        /// </summary>
        /// <param name="execute">Action to execute.</param>
        /// <param name="canExecute">Function to determine if can execute.</param>
        protected Command(Action<object> execute, Func<object, bool> canExecute) : this(execute)
        {
            this._canExecute = canExecute;
        }

        /// <summary>
        /// Command that takes an action to execute.
        /// </summary>
        /// <param name="execute">Action to execute.</param>
        /// <param name="canExecute">Function to determine if can execute.</param>
        public Command(Action execute, Func<bool> canExecute) : this(o => execute())
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            if (canExecute != null)
            {
                this._canExecute = o => canExecute();
            }
        }

        /// <summary>
        /// Invoke the CanExecute method to determine if it can be executed.
        /// </summary>
        /// <param name="parameter">Parameter to test and pass to CanExecute.</param>
        /// <returns>If it can be executed.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// Event handler raised when CanExecute changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => _weakEventManager.AddEventHandler(value);
            remove => _weakEventManager.RemoveEventHandler(value);
        }

        /// <summary>
        /// Execute the command with or without a parameter.
        /// </summary>
        /// <param name="parameter">Parameter to pass to execute method.</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// Manually raise a CanExecuteChanged event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            _weakEventManager.HandleEvent(this, EventArgs.Empty, nameof(CanExecuteChanged));
        }
    }
}

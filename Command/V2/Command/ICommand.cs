namespace Command.V2.Command
{
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
        void Undo();
    }
}

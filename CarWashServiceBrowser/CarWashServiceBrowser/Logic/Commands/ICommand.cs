namespace CarWashServiceBrowser.Logic
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}

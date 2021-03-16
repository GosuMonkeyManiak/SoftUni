namespace Logger.Contracts
{
    public interface ILogableFileInfo
    {
        int Size { get; }

        void Write(string msg);
    }
}
namespace MessageAPI.Interfaces
{
    public interface IRealTimeMessage
    {
        string Text { get; }
        object Data { get; }
    }
}

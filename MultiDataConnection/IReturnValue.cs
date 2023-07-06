namespace MultiDataConnection
{
    public interface IReturnValue<T>
    {
        bool Error { get; set; }

        string Message { get; set; }

        T Data { get; set; }
    }
}

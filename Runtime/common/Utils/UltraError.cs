namespace Ultraio
{
    public class UltraError
    {
        /// <summary>Message of the error</summary>
        public string Message
        {
            get; private set;
        }

        public UltraError(string message)
        {
            Message = message;
        }
    }
}
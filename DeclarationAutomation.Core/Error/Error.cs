namespace DeclarationAutomation.Core.ErrorReporting
{
    public class Error : IError
    {
        public string Message { get; private set; }

        public Error(string message)
        {
            Message = message;
        }
    }
}

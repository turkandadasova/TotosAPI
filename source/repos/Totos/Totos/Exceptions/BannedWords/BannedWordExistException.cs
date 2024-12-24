namespace Totos.Exceptions.BannedWords
{
    public class BannedWordExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }

        public BannedWordExistException()
        {
            ErrorMessage = "Bannedword artiq movcuddur";
        }

        public BannedWordExistException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}

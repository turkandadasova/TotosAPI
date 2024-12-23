using System.Runtime.Serialization;

namespace Totos.Exceptions.Languages
{
    public class LanguageExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }

        public LanguageExistException()
        {
            ErrorMessage = "Dil artiq movcuddur";
        }

        public LanguageExistException(string? message) : base(message)
        {
            ErrorMessage = message;
        }


    }
}

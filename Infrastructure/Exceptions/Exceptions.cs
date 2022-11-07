
namespace Core.Helpers
{
    public class Exceptions
    {
        public class UnprocessableEntity : Exception
        {
            public new static string Message;
            public UnprocessableEntity() { Message = "Unprocessable Entity"; }
            public UnprocessableEntity(string message) { Message = message; }
        }

    }
}

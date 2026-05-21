namespace OOP_Assessment.Exceptions
{
    public class InvalidTripException : Exception
    {
        public InvalidTripException(string message) : base(message) { }
        public InvalidTripException(string message, Exception inner) : base(message, inner) { }
    }
}

using System;

namespace BashSoft.Exceptions
{
    public class InvalidComparionsQueryException : Exception
    {
        private const string InvalidComparionQuery = "The comparison query you want, does not exist in the context of the current program!";

        public InvalidComparionsQueryException()
            : base(InvalidComparionQuery)
        {
        }

        public InvalidComparionsQueryException(string message) : base(message)
        {
        }
    }
}

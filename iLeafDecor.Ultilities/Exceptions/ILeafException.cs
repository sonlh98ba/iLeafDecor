using System;

namespace iLeafDecor.Ultilities.Exceptions
{
    public class ILeafException : Exception
    {
        public ILeafException()
        {
        }

        public ILeafException(string message)
            : base(message)
        {
        }

        public ILeafException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

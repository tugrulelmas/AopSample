using System;

namespace AopSample.Exceptions
{
    public class DenialException : Exception
    {
        public DenialException(string message)
            : base(message) {
        }
    }
}
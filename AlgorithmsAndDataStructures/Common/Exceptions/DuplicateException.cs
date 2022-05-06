using System;

namespace AlgorithmsAndDataStructures.Common.Exceptions
{
    [Serializable]
    public class DuplicateException : Exception
    {
        private static readonly string _message = "Duplicate item";

        public DuplicateException() : base(_message)
        {}
        
        public DuplicateException(Exception inner) : base(_message, inner)
        {}
    }
}
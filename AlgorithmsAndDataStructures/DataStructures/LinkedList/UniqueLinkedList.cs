using AlgorithmsAndDataStructures.Common.Exceptions;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedList
{
    public class UniqueLinkedList<T> : LinkedList<T>
    {
        public new void Append(T data)
        {
            CheckOnDuplicate(data);
            base.Append(data);
        }

        public new void Prepend(T data)
        {
            CheckOnDuplicate(data);
            base.Prepend(data);
        }

        public new bool TryAppendAfter(T data, T after)
        {
            CheckOnDuplicate(data);
            return base.TryAppendAfter(data, after);
        }

        private void CheckOnDuplicate(T data)
        {
            if (Contains(data))
                throw new DuplicateException();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Common.Classes;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedList
{
    public abstract class AbstractLinkedList<T> : IEnumerable<T>
    {
        protected Node<T> _head;

        protected Node<T> _tail;

        protected int _count;
        
        public int Count => _count;

        public bool IsEmpty => _count == 0;

        public abstract void Append(T data);

        public abstract void Prepend(T data);

        public abstract bool Remove(T data);

        public virtual void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public virtual bool Contains(T data)
        {
            var current = _head;

            while (current is  not null)
            {
                if (current.Data.Equals(data))
                    return true;

                current = current.Next;
            }

            return false;
        }
        
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var current = _head;

            while (current is not null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
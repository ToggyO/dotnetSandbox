using System;
using System.Collections;
using System.Collections.Generic;

using AlgorithmsAndDataStructures.Common.Classes;

namespace AlgorithmsAndDataStructures.DataStructures.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private Node<T> _head;

        private int _count;

        public bool IsEmpty => _count == 0;

        public int Count => _count;

        public void Push(T data)
        {
            var node = new Node<T>(data);

            node.Next = _head;
            _head = node;
            _count++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            var temp = _head;

            _head = temp.Next;
            _count--;

            return temp.Data;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");

            return _head.Data;
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) this).GetEnumerator();

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
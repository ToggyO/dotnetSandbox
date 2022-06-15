using AlgorithmsAndDataStructures.Common.Classes;
using AlgorithmsAndDataStructures.Common.Interfaces;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedList
{
    public class LinkedList<T> : AbstractLinkedList<T>, ISafelyAppendableList<T>
    {
        public override void Append(T data)
        {
            var node = new Node<T>(data);

            if (_head is null)
                _head = node;
            else
                _tail.Next = node;

            _tail = node;
            _count++;
        }

        public override void Prepend(T data)
        {
            var node = new Node<T>(data);
            
            if (_head is null)
                _tail = node;

            node.Next = _head;
            _head = node;
            
            _count++;
        }

        public override bool Remove(T data)
        {
            Node<T> current = _head;
            Node<T> previous = null;

            while (current is not null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous is not null)
                    {
                        previous.Next = current.Next;
                        if (current.Next is null)
                            _tail = previous;
                    }
                    else
                    {
                        _head = current.Next;
                        if (_head is null)
                            _tail = null;
                    }

                    _count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        public bool TryAppendAfter(T data, T after)
        {
            var node = new Node<T>(data);

            Node<T> nodeAfter = null;
            Node<T> current  = _head;

            while (current is not null)
            {
                if (current.Data.Equals(after))
                {
                    nodeAfter = current;
                    break;
                }

                current = current.Next;
            }
            
            if (nodeAfter is null)
                return false;

            if (nodeAfter.Next is null)
                _tail = node;
            else
                node.Next = nodeAfter.Next;

            nodeAfter.Next = node;
            
            _count++;
            return true;
        }
    }
}
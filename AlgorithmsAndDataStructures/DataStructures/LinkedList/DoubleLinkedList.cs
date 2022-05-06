using System.Collections;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Common.Classes;
using AlgorithmsAndDataStructures.Common.Interfaces;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedList
{
    public class DoubleLinkedList<T> : AbstractLinkedList<T>, ISafelyAppendableList<T>, IEnumerable<T>
    {
        private new DoubleNode<T> _head;

        private new DoubleNode<T> _tail;

        public override void Append(T data)
        {
            var node = new DoubleNode<T>(data);

            if (_head is null)
                _head = node;
            else
            {
                node.Previous = _tail;
                _tail.Next = node;
            }

            _tail = node;
            _count++;
        }

        public override void Prepend(T data)
        {
            var node = new DoubleNode<T>(data);

            if (_head is null)
                _tail = node;
            else
            {
                node.Next = _head;
                _head.Previous = node;
            }

            _head = node;
            _count++;
        }

        public override bool Remove(T data)
        {
            var current = _head;
 
            // поиск удаляемого узла
            while (current is not null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }

            if (current is null)
                return false;
            
            // если узел не последний
            if(current.Next is not null)
                current.Next.Previous = current.Previous;
            else
                // если последний, переустанавливаем tail
                _tail = current.Previous;

            // если узел не первый
            if(current.Previous is not null)
                current.Previous.Next = current.Next;
            else
                // если первый, переустанавливаем head
                _head = current.Next;

            _count--;
            return true;
        }

        public bool TryAppendAfter(T data, T after)
        {
            var node = new DoubleNode<T>(data);

            DoubleNode<T> nodeAfter = null;
            DoubleNode<T> current = _head;

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

            node.Previous = nodeAfter;

            if (nodeAfter.Next is not null)
            {
                node.Next = nodeAfter.Next;
                nodeAfter.Next.Previous = node;
            }
                
            nodeAfter.Next = node;

            _count++;
            return true;
        }
        
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
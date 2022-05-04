namespace AlgorithmsAndDataStructures.Common.Classes
{
    public class DoubleNode<T> : Node<T>
    {
        public new DoubleNode<T> Next { get; set; }

        public DoubleNode<T> Previous { get; set; }

        public DoubleNode(T data) : base(data)
        {}
    }
}
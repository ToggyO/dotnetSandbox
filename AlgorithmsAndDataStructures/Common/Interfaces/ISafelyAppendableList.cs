namespace AlgorithmsAndDataStructures.Common.Interfaces
{
    public interface ISafelyAppendableList<in T>
    {
        public bool TryAppendAfter(T data, T after);
    }
}
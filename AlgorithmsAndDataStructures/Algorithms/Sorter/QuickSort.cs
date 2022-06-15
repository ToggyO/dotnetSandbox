using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Sorter
{
    public static partial class Sorter
    {
        public static void QuickSort(IList<int> source, int leftIndex, int rightIndex)
        {
            if (source.Count == 0)
                return;

            if (leftIndex >= rightIndex)
                return;
            
            int pivot = leftIndex + (rightIndex - leftIndex) / 2;
            int l = leftIndex;
            int r = rightIndex;

            while (l <= r)
            {
                while (source[l] < source[pivot])
                    l++;

                while (source[r] > source[pivot])
                    r--;

                if (l <= r)
                {
                    (source[l], source[r]) = (source[r], source[l]);
                    l++;
                    r--;
                }
            }
            
            if (leftIndex < r)
                QuickSort(source, leftIndex, r);
            
            if (rightIndex > l)
                QuickSort(source, l, rightIndex);
        }
    }
}
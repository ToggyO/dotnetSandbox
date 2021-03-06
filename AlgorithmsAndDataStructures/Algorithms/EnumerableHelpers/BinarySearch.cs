using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.EnumerableHelpers
{
    public static partial class EnumerableHelpers
    {
        public static int BinarySearch(IList<int> source, int desired)
        {
            int low = 0;
            int high = source.Count - 1;
            int mid;
            int position = -1;

            while (low <= high)
            {
                mid = low + (high - low) / 2;

                int midElem = source[mid];
                if (midElem == desired)
                {
                    position = mid;
                    break;
                }

                if (desired >= midElem)
                    low = mid + 1;
                else
                    high = mid;
            }

            return position;
        }
    }
}
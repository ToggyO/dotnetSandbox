using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.EnumerableHelpers
{
    public static partial class EnumerableHelpers
    {
        public static int Sum(IList<int> source)
        {
            if (source.Count == 0)
                return 0;
            return source[0] + Sum(source.Skip(1).ToArray());
        }

        public static int Count(IList<int> source)
        {
            if (source.Count == 0)
                return 0;
            return 1 + Count(source.Skip(1).ToArray());
        }

        public static int Max(IList<int> source)
        {
            int max = 0;
            foreach (var elem in source)
            {
                if (elem > max)
                    max = elem;
            }

            return max;
        }
    }
}
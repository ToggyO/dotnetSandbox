using System.Runtime.InteropServices;

namespace UnsafeProject.Pointers
{
    public unsafe class PointerOperators
    {
        public static void DiscoverAddAndSubstruct()
        {
            const int count = 3;
            int[] numbers = new int[count] { 10, 20, 30 };
            fixed (int* pointerToFirst = &numbers[0])
            {
                int* pointerToLast = pointerToFirst + (count - 1);

                Console.WriteLine($"Value {*pointerToFirst} at address {(long)pointerToFirst}");
                Console.WriteLine($"Value {*pointerToLast} at address {(long)pointerToLast}");
            }
        }

        public static void DiscoverSubstruct()
        {
            int* numbers = stackalloc int[] { 0, 1, 2, 3, 4, 5 };

            int* p1 = &numbers[1];
            int* p2 = &numbers[5];
            long result = p2 - p1;

            Console.WriteLine(result);
        }
    }
}

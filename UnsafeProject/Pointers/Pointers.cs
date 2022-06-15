using UnsafeProject.MemoryUsage.Objects;

namespace UnsafeProject.Pointers
{
    public unsafe class Pointers
    {
        public static void Create()
        {
            int num = 7;
            int* p = &num;

            Console.WriteLine("Pointer: {0}", *p);

            ulong address = (ulong) p;

            Console.WriteLine("Address: {0}", address);

            Console.WriteLine("MyStruct");

            var myStruct = new MyStruct();
            var myStructP = &myStruct;

            ulong mystrAddress = (ulong) myStructP;

            Console.WriteLine("MyStruct address: {0}", mystrAddress);
        }

        public static void CalculateAndPrintSquare(int size)
        {
            int* square = stackalloc int[size];
            int* p = square;

            for (int i = 1; i <= size; i++, p++)
                *p = i * i;

            for (int i = 0; i < size; i++)
                Console.WriteLine(square[i]);
        }
    }
}

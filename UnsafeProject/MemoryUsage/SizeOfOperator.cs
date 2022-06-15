using System.Runtime.InteropServices;
using UnsafeProject.MemoryUsage.Objects;

namespace UnsafeProject.MemoryUsage
{
    public unsafe class SizeOfOperator
    {
        public static void Discover()
        {
            Console.WriteLine("Size of byte: {0}", sizeof(byte));
            Console.WriteLine("Size of double: {0}", sizeof(double));

            DisplaySizeOf<MyStruct>();
            DisplaySizeOf<decimal>();

            var myStructSize = sizeof(MyStruct*);
            Console.WriteLine("Size of {0} - {1}", nameof(MyStruct), myStructSize);

            DisplayMarshalSizeOf<MyStruct>();

            DisplayMarshalSizeOf<MyClass>();
        }

        private static void DisplaySizeOf<T>() where T : unmanaged
        {
            Console.WriteLine($"Size of {typeof(T)} is {sizeof(T)}");
        }

        private static void DisplayMarshalSizeOf<T>()
        {
            var size = Marshal.SizeOf<T>();
            Console.WriteLine("Marshal.SizeOf {0} - {1}", typeof(T), size);
        }

        public static T ThiscallCombine<T>(delegate* unmanaged[Thiscall]<T, T, T> combinator, T left, T right) =>
            combinator(left, right);
    }
}

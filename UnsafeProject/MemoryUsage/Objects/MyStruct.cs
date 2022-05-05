using System.Runtime.InteropServices;

namespace UnsafeProject.MemoryUsage.Objects
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MyStruct
    {
        public MyStruct(int n, double r) => (integer, real) = (n, r);

        public int integer;

        public double real;
    }
}

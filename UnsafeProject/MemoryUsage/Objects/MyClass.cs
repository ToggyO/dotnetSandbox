using System.Runtime.InteropServices;

namespace UnsafeProject.MemoryUsage.Objects
{
    [StructLayout(LayoutKind.Sequential)]
    public class MyClass
    {
        public MyClass() {}

        public MyClass(int n, double r) => (integer, real) = (n, r);

        public int integer;

        public double real;
    }
}

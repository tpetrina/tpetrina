using System.Diagnostics;

namespace Debugger
{
    [DebuggerDisplay("[Prop = {MyProperty}]")]
    internal class MyClass
    {
        public string MyProperty { get; set; }

        public MyClass()
        {
            this.MyProperty = "Hello world";
        }
    }
}
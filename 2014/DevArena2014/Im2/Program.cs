using System.Linq;
using Microsoft.FSharp.Collections;
using Microsoft.FSharp.Control;
using Microsoft.FSharp.Core;

namespace Im2
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = FSharpList<string>.Empty;
            list = FSharpList<string>.Cons("Hello", list);
        }
    }
}

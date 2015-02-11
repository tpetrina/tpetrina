using System.Diagnostics;

namespace Recursion
{
    class Program
    {

        static string Reverse(string input)
        {
            var first = input.Substring(0, 1);

            if (input.Length > 1)
            {
                return Reverse(input.Substring(1)) + first;
            }

            Debugger.Break();
            return input;
        }

        static void Main(string[] args)
        {
            var input = "Did you mean recursion?";
            for (var index = 0; index < input.Length; ++index)
            {
                var first = input.Substring(0, 1);
                if (index == input.Length - 1)
                    Debugger.Break();
            }
            Reverse(input);
        }
    }
}

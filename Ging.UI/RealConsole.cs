using System;
using System.Diagnostics.CodeAnalysis;

namespace CloudAcademy.CA151.Lab.Ging.UI
{
    [ExcludeFromCodeCoverage]
    class RealConsole : IConsole
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        public void WriteLine(Object o)
        {
            Console.WriteLine(o.ToString());
        }

    }
}

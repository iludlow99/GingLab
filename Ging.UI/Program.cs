using System;
using System.Diagnostics.CodeAnalysis;

namespace CloudAcademy.CA151.Lab.Ging.UI
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new ProgramUI(new RealConsole());
            ui.Run();
        }
    }
}

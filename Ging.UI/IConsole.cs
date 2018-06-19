using System;

namespace CloudAcademy.CA151.Lab.Ging.UI
{
    public interface IConsole
    {
        void WriteLine(string message);
        void WriteLine();
        void Write(string message);
        string ReadLine();
        void WriteLine(Object o);
    }
}

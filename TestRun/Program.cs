using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestRun
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = typeof(OneGame.Control.GameControl);

            Assembly assembly = Assembly.LoadFile(@"C:\Users\NicholasThai\source\repos\Clone\TempConsole\bin\Debug\TempConsole.dll");
            Type t = assembly.GetType("TempConsole.Program");
            Activator.CreateInstance(t);
        }
    }
}

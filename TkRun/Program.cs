using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TkRun
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly DLL = Assembly.LoadFile(@"C:\Users\NicholasThai\source\repos\Clone\TkTest\bin\Release\TkTest.dll");
            /*foreach (Type type in DLL.GetExportedTypes())
            {
                dynamic c = Activator.CreateInstance(type);
                c.Output(@"Hello");
            }
            Console.ReadLine();
            */
            using (dynamic game = Activator.CreateInstance(DLL.GetType("TkTest.Game"), 800, 600, "LearnOpenTK"))
            {
                game.Run(60.0);
            }
        }
    }
}

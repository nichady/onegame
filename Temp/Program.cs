using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Temp
{
    class Program
    {
        private static string GameFolder { get; }

        static Program()
        {
            string dataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OneGame");

            GameFolder = Path.Combine(dataFolder, "Games");

            Directory.CreateDirectory(GameFolder);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Retrieve().Count);
            Console.ReadLine();
        }

        internal static List<Assembly> Retrieve()
        {
            var assemblies = new List<Assembly>();

            foreach (string s in Directory.GetFiles(GameFolder))
            {
                if (Path.GetExtension(s) != ".dll") continue;
                try
                {
                    Assembly assembly = Assembly.LoadFile(s);
                    assemblies.Add(assembly);
                }
                catch (Exception) { }
            }

            return assemblies;
        }
    }
}

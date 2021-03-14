using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            /*
            new Temp2(); new Temp3(); // load on launch?
            InitializeComponent();

            string es = "def ";
            var a = Assembly.LoadFrom(@"C:\Users\NicholasThai\AppData\Roaming\OneGame\Games\TestGame.dll");

            foreach (Type t in a.GetExportedTypes())
            {
                es += " " + t.FullName;
            }

            Controls.Add(new Label { Text = es, Dock = DockStyle.Fill });
            */
        }
    }

    public class Temp2 : OpenTK.GameWindow { }
    public class Temp3 : OpenTK.GLControl { }
}

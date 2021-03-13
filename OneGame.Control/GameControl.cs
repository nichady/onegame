using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneGame.Control
{
    public abstract class GameControl : GLControl
    {
        public GameControl()
        {
            Dock = DockStyle.Fill;
        }
    }
}

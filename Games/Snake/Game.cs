using OneGame.Entry;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    [GameEntry]
    public sealed class Game : Form
    {
        public Game()
        {
            Text = "Snake";
            BackColor = Color.Green;
        }
    }
}

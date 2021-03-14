using OneGame.Entry;
using Snake.Library;
using Snake.Panels;
using System.Windows.Forms;

namespace Snake
{
    [GameEntry]
    public sealed partial class GameWindow : Form
    {
        private ContentPanel panel;

        public GameWindow()
        {
            InitializeComponent();

            panel = new Panels.Menu();
            Controls.Add(panel);
        }

        internal ContentPanel Panel
        {
            get { return panel; }
            set
            {
                Controls.Remove(panel);
                Controls.Add(value);
                panel = value;
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }
        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake.Panels
{
    internal sealed class Menu : ContentPanel
    {
        internal Menu()
        {
            PictureBox play = new PictureBox();
            PictureBox quit = new PictureBox();

            BackColor = Color.Black;

            play.Anchor = AnchorStyles.None;
            play.BackgroundImage = Properties.Resources.play;
            play.BackgroundImageLayout = ImageLayout.Stretch;
            play.Click += new EventHandler(Play_MouseClick);
            play.Location = new Point(298, 176);
            play.MouseEnter += new EventHandler(Play_MouseEnter);
            play.MouseLeave += new EventHandler(Play_MouseLeave);
            play.Size = new Size(204, 54);

            quit.Anchor = AnchorStyles.None;
            quit.BackgroundImage = Properties.Resources.quit;
            quit.BackgroundImageLayout = ImageLayout.Stretch;
            quit.Click += new EventHandler(Quit_MouseClick);
            quit.Location = new Point(298, 251);
            quit.MouseEnter += new EventHandler(Quit_MouseEnter);
            quit.MouseLeave += new EventHandler(Quit_MouseLeave);
            quit.Size = new Size(204, 54);

            Controls.Add(play);
            Controls.Add(quit);
        }

        private void Play_MouseClick(object sender, EventArgs e)
        {
            if (((MouseEventArgs) e).Button == MouseButtons.Left) ((GameWindow)FindForm()).Panel = new Game();
        }
        private void Play_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox) sender).BackgroundImage = Properties.Resources.play_hover;
        }
        private void Play_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox) sender).BackgroundImage = Properties.Resources.play;
        }
        private void Quit_MouseClick(object sender, EventArgs e)
        {
            if (((MouseEventArgs) e).Button == MouseButtons.Left) Environment.Exit(0);
        }
        private void Quit_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox) sender).BackgroundImage = Properties.Resources.quit_hover;
        }
        private void Quit_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox) sender).BackgroundImage = Properties.Resources.quit;
        }
    }
}

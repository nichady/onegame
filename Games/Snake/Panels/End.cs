using Snake.Library;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snake.Panels
{
    internal sealed class End : ContentPanel
    {
        private readonly Timer timer = new Timer();

        internal End(int score)
        {
            Label gameOver = new Label();
            PictureBox playAgain = new PictureBox();
            Panel top = new Panel();
            Panel bottom = new Panel();

            BackColor = Color.Black;

            gameOver.Dock = DockStyle.Fill;
            gameOver.Font = new Font("Microsoft Sans Serif", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gameOver.ForeColor = Color.Lime;
            gameOver.Text = "Game Over!\nScore: " + score;
            gameOver.TextAlign = ContentAlignment.TopCenter;

            playAgain.Anchor = AnchorStyles.None;
            playAgain.BackgroundImage = Properties.Resources.playAgain;
            playAgain.BackgroundImageLayout = ImageLayout.Stretch;
            playAgain.Click += new EventHandler(PlayAgain_MouseClick);
            playAgain.MouseEnter += new EventHandler(PlayAgain_MouseEnter);
            playAgain.MouseLeave += new EventHandler(PlayAgain_MouseLeave);
            playAgain.Size = new Size(204, 54);

            top.Controls.Add(gameOver);
            top.Dock = DockStyle.Fill;
            top.Location = new Point(0, 0);
            top.Size = new Size(800, 450);

            bottom.Controls.Add(playAgain);
            bottom.Dock = DockStyle.Bottom;
            bottom.Location = new Point(0, 345);
            bottom.Size = new Size(800, 105);

            timer.Interval = 1000/Settings.Speed;
            timer.Tick += DetectKey;
            timer.Start();

            Controls.Add(top);
            Controls.Add(bottom);
        }
        private void DetectKey(object sender, EventArgs e)
        {
            if (Input.KeyPressed(Keys.Enter) || Input.KeyPressed(Keys.Space))
            {
                timer.Stop();
                ((GameWindow)FindForm()).Panel = new Game();
            }
        }
        private void PlayAgain_MouseClick(object sender, EventArgs e)
        {
            if (((MouseEventArgs) e).Button == MouseButtons.Left)
            {
                timer.Stop();
                ((GameWindow)FindForm()).Panel = new Game();
            }
        }
        private void PlayAgain_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox) sender).BackgroundImage = Properties.Resources.playAgain_hover;
        }
        private void PlayAgain_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox) sender).BackgroundImage = Properties.Resources.playAgain;
        }
    }
}

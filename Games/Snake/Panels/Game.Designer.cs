using System.Drawing;
using System.Windows.Forms;

namespace Snake.Panels
{
    internal sealed partial class Game : ContentPanel
    {
        private readonly PictureBox canvas = new PictureBox();
        private readonly Label scoreCount = new Label();

        private void InitializeComponent()
        {
            Label scoreName = new Label();

            canvas.Anchor = AnchorStyles.None;
            canvas.BackColor = Color.Black;
            canvas.Location = new Point(188, 13);
            canvas.Size = new Size(425, 425);
            canvas.Paint += Canvas_Paint;

            scoreName.AutoSize = true;
            scoreName.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            scoreName.Location = new Point(620, 13);
            scoreName.Text = "Score:";

            scoreCount.AutoSize = true;
            scoreCount.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            scoreCount.Location = new Point(692, 13);
            scoreCount.Text = "";

            Controls.Add(canvas);
            Controls.Add(scoreName);
            Controls.Add(scoreCount);
        }
    }
}

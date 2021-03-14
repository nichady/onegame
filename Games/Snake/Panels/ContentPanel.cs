using System.Windows.Forms;

namespace Snake.Panels
{
    internal abstract class ContentPanel : Panel
    {
        internal ContentPanel()
        {
            Dock = DockStyle.Fill;
            Size = new System.Drawing.Size(800, 450);
        }
    }
}

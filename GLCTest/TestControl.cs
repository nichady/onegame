using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.Windows.Forms;
using OpenTK.Graphics.ES20;
using System.Drawing;

namespace GLCTest
{
    public sealed class TestControl : GLControl
    {
        public TestControl()
        {
            Dock = DockStyle.Fill;

            Load += new EventHandler(OnLoad);
            Resize += new EventHandler(OnResize);
            Paint += new PaintEventHandler(OnPaint);
        }

        /*
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            glControl1_Resize(this, EventArgs.Empty);   // Ensure the Viewport is set up correctly
            GL.ClearColor(Color.Crimson);
        }
        goes in form, not control
        */

        private void OnLoad(object sender, EventArgs e)
        {
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            //Code goes here
        }

        private void OnResize(object sender, EventArgs e) // dont know if needed
        {
            if (ClientSize.Height == 0) ClientSize = new Size(ClientSize.Width, 1);
            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            MakeCurrent();
            GL.Clear(ClearBufferMask.ColorBufferBit);
         //   Context.SwapBuffers(); // ?
            SwapBuffers();
        }
    }
}

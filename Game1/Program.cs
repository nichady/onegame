using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game1
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class Form1 : Form
    {
        public static int GWL_STYLE = -16;
        public static int WS_CHILD = 0x40000000;

        [DllImport("user32.dll")]
        public static extern void SetParent(IntPtr h1, IntPtr h2);

        [DllImport("user32.dll")]
        public static extern void SetWindowLong(IntPtr h1, int h2, dynamic l);

        [DllImport("user32.dll")]
        public static extern void ShowWindow(IntPtr h1, int i);

        [DllImport("user32.dll")]
        public static extern void SetWindowPos(IntPtr h1, IntPtr i, int b, int a, int j, int k, uint u);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        Game1 game;

        internal Form1()
        {
            game = new Game1();
            Shown += _Shown;
            /*game.Window.IsBorderless = true;
            game.IsMouseVisible = true;

            SetWindowPos(
              game.Window.Handle,
              IntPtr.Zero,
              0,
              0,
              0,
              0,
              0x0401 // NOSIZE | SHOWWINDOW
            );

            SetParent(game.Window.Handle, Handle);
            SetWindowLong(game.Window.Handle, -20, 0x08000000); // WS_EX_NOACTIVATE, to prevent parent window from being deactivated when this window is clicked, yet keep receiving input
            ShowWindow(game.Window.Handle, 1); // SHOWNORMAL*/

            /*IntPtr hostHandle = Handle;
            IntPtr guestHandle = game.Window.Handle;
            SetWindowLong(guestHandle, GWL_STYLE, GetWindowLong(guestHandle, GWL_STYLE) | WS_CHILD);
            SetParent(guestHandle, hostHandle);*/

            //game.Run();
        }

        internal void _Shown(object sender, EventArgs e)
        {
            SetWindowLong(game.Window.Handle, -8, new HandleRef(this, Handle));
            game.Run();
        }
    }
}

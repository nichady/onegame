using System;
using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.OneNote;
using Application = Microsoft.Office.Interop.OneNote.Application;
using Extensibility;
using Microsoft.Office.Core;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;
using System.Drawing.Imaging;
using System.IO;

namespace OneGame
{
    [ComVisible(true)]
    [Guid("CD37B0D2-B19E-4B9A-BD66-12573E8DBA04")]
    [ProgId("OneGame.AddIn")]
    public sealed class AddIn : IDTExtensibility2, IRibbonExtensibility
    {
        private Application _app = new Application();

        public void OnConnection(object app, ext_ConnectMode connectMode, object addInInst, ref Array custom) => _app = (Application)app;
        public void OnAddInsUpdate(ref Array custom) { }
        public void OnStartupComplete(ref Array custom) { }
        public void OnBeginShutdown(ref Array custom) => _app = null;
        public void OnDisconnection(ext_DisconnectMode removeMode, ref Array custom)
        {
            _app = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public string GetCustomUI(string ribbonId) => Properties.Resources.ribbon;


        public void ShowHello(IRibbonControl control)
        {
            using (var form = new Form1())
            {
                form.ShowDialog(new Win32WindowHandle(new IntPtr((long) _app.Windows.CurrentWindow.WindowHandle)));
            }
        }
        private sealed class Win32WindowHandle : IWin32Window
        {
            internal Win32WindowHandle(IntPtr windowHandle) => Handle = windowHandle;

            public IntPtr Handle { get; }
        }
        public IStream GetImage(string imageName)
        {
            var mem = new MemoryStream();
            Properties.Resources.HelloWorld.Save(mem, ImageFormat.Png);
            return new CCOMStreamWrapper(mem);
        }
    }
}

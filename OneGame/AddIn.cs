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
using System.Text;
using System.Collections.Generic;
using System.Drawing;

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

        Dictionary<string, GameInfo> games = new Dictionary<string, GameInfo>();
        public string GetContent(IRibbonControl control)
        {
            games = Games.Retrieve(); // only fires at launch

            var builder = new StringBuilder("<menu xmlns='http://schemas.microsoft.com/office/2006/01/customui'>");

            foreach (var entry in games)
            {
                string id = entry.Key;
                GameInfo info = entry.Value;
                builder.Append($"<button id='{id}' onAction='LaunchGame' label='{info.Name}' imageMso='FileDocumentInspect'/>");
            }

            builder.Append($"<menuSeparator id='{Util.GenerateUniqueVstoId()}'/>");
            builder.Append($"<button id='{Util.GenerateUniqueVstoId()}' label='Install Games ({games.Count})' imageMso='ShapeUpArrow'/>");
            builder.Append("</menu>");
            return builder.ToString();
        }

        public void LaunchGame(IRibbonControl control)
        {
            using (var form = new Form1()) // TODO using?
            {
                form.Text = games[control.Id].Name;
                form.ShowDialog(new Win32WindowHandle(new IntPtr((long)_app.Windows.CurrentWindow.WindowHandle)));
            }
        }

        public Bitmap /*Image*/ GetGameIcon(IRibbonControl control)
        {
            return games[control.Id].Icon;
        }


        private sealed class Win32WindowHandle : IWin32Window
        {
            internal Win32WindowHandle(IntPtr windowHandle) => Handle = windowHandle;

            public IntPtr Handle { get; }
        }
        /*public IStream GetImage(string imageName)
        {
            var ms = new MemoryStream();
            Properties.Resources.HelloWorld.Save(ms, ImageFormat.Png);
            return new CCOMStreamWrapper(ms);
        }*/
        public IStream GetImage(string imageName)
        {
            try
            {
                var ms = new MemoryStream();
                ((Bitmap)Properties.Resources.ResourceManager.GetObject(imageName)).Save(ms, ImageFormat.Png);
                return new CCOMStreamWrapper(ms);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

using System;
using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.OneNote;
using Application = Microsoft.Office.Interop.OneNote.Application;
using Extensibility;
using Microsoft.Office.Core;
using System.Windows.Forms;

namespace OneGame
{
    [Guid("CD37B0D2-B19E-4B9A-BD66-12573E8DBA04"), ProgId("OneGame.AddIn")]
    public class AddIn : IDTExtensibility2, IRibbonExtensibility
    {
        Application onApp = new Application();

        public void OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref Array custom) => onApp = (Application)Application;
        public void OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {
            onApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public void OnAddInsUpdate(ref Array custom) { }
        public void OnStartupComplete(ref Array custom) { }
        public void OnBeginShutdown(ref Array custom) => onApp = null;
        public string GetCustomUI(string RibbonID) => Properties.Resources.ribbon;

        public void ShowHello(IRibbonControl control)
        {
            string id = onApp.Windows.CurrentWindow.CurrentPageId;
            MessageBox.Show("Current Page ID = " + id, "Hello World!");
            //new Form1().Show();
            //CreateChildForm();
        }
    }
}

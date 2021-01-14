using System;
using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.OneNote;
using Application = Microsoft.Office.Interop.OneNote.Application;
using Extensibility;
using Microsoft.Office.Core;
using System.Windows.Forms;

namespace OneGame
{
    [GuidAttribute("CD37B0D2-B19E-4B9A-BD66-12573E8DBA04"), ProgId("OneGame.Class1")]
    public class Class1 : IDTExtensibility2, IRibbonExtensibility
    {
        Application onApp = new Application();

        public void OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
        {
            onApp = (Application)Application;
        }

        public void OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {
            onApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        public void OnAddInsUpdate(ref Array custom) { }
        public void OnStartupComplete(ref Array custom) { }
        public void OnBeginShutdown(ref Array custom)
        {
            if (onApp != null) onApp = null;
        }

        public string GetCustomUI(string RibbonID)
        {
            return Properties.Resources.ribbon;
        }

        public void showHello(IRibbonControl control)
        {
            string id = onApp.Windows.CurrentWindow.CurrentPageId;
            MessageBox.Show("Current Page ID = " + id, "Hello World!");
        }
    }
}

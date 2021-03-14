using System.Collections;
using System.Windows.Forms;

namespace Snake.Library
{
    internal static class Input
    {
        private static readonly Hashtable keyTable = new Hashtable();

        internal static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null) return false;
            return (bool) keyTable[key];
        }
        internal static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}

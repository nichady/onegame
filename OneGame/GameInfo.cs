using System;
using System.Drawing;

namespace OneGame
{
    internal struct GameInfo
    {
        internal string Name { get; }
        internal string Version { get; }
        internal Bitmap Icon { get; }
        internal Type Entry { get; }

        internal GameInfo(string name, string version, Bitmap icon, Type entry)
        {
            Name = name;
            Version = version;
            Icon = icon;
            Entry = entry;
        }
    }
}

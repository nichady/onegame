using OneGame.Entry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace OneGame
{
    internal static class Games // GameManager
    {
        private static string GameFolder { get; }
        private static string GameDataFolder { get; }

        static Games()
        {
            string dataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OneGame");

            GameFolder = Path.Combine(dataFolder, "Games");
            GameDataFolder = Path.Combine(dataFolder, "GameData");

            Directory.CreateDirectory(GameFolder);
            Directory.CreateDirectory(GameDataFolder);
        }

        internal static void Install()
        {

        }

        internal static Dictionary<string, GameInfo> Retrieve()
        {
            var games = new Dictionary<string, GameInfo>();
            foreach (string s in Directory.GetFiles(GameFolder))
            {
                if (Path.GetExtension(s) != ".dll") continue;
                try
                { // TODO bug: this locks dll files, even some which are not valid game entries
                    Assembly assembly = Assembly.LoadFrom(s);
                    foreach (Type t in assembly.GetExportedTypes())
                    {
                        if (t.GetCustomAttribute<GameEntry>() == null) continue;
                        if (!t.IsSubclassOf(typeof(Form))) continue;

                        games.Add(Util.GenerateUniqueVstoId(), new GameInfo
                        (
                            name: assembly.GetName().Name,
                            version: assembly.GetName().Version.ToString(),
                            icon: Icon.ExtractAssociatedIcon(assembly.Location).ToBitmap(),
                            entry: t
                        ));
                        break;
                    }
                }
                catch (Exception) { }
            }

            return games;
        }
    }
}

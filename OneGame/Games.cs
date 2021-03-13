using OneGame.Control;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OneGame
{
    internal static class Games
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
                {
                    Assembly assembly = Assembly.LoadFrom(s);
                    foreach (Type t in assembly.GetExportedTypes())
                    {
                        if (t.GetCustomAttribute<GameEntry>() == null) continue;
                        if (!t.IsSubclassOf(typeof(GameControl))) continue;

                        games.Add(Util.GenerateUniqueVstoId(), new GameInfo
                        (
                            name: assembly.GetName().Name,
                            version: assembly.GetName().Version.ToString(),
                            icon: t. // TODO ???
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

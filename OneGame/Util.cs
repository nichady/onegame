using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneGame
{
    internal static class Util
    {
        private static int i = 0;
        internal static string GenerateUniqueVstoId() => "_custom_" + i++;
    }
}

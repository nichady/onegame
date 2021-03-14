using System;

namespace OneGame.Entry
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class GameEntry : Attribute
    {
        public GameEntry() { }
    }
}

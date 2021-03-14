namespace Snake.Library
{
    internal enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    internal static class Settings
    {
        internal static int Width {get; set;} = 18;
        internal static int Height {get; set;} = 18;
        internal static int Speed {get; set;} = 14;
        internal static int Points {get; set;} = 1;
    }
}

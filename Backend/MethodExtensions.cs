using Microsoft.Xna.Framework;
using WorldBuilder.Data;
using Console = SadConsole.Console;

namespace WorldBuilder.Backend
{
    public static class MethodExtensions
    {
        public static void Print(this Console console, int row, string text)
        {
            int col = (Program.width - text.Length) / 2;
            if (col < 0)
                col = 0;

            console.Print(col, row, text);
        }

        public static void Print(this Console console, int row, string text, Color color)
        {
            int col = (Program.width - text.Length) / 2;
            if (col < 0)
                col = 0;

            console.Print(col, row, text, color);
        }

        public static void SwitchWorld(this Console console, World world)
        {
            //TODO
        }
    }
}
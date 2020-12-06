using Microsoft.Xna.Framework;
using Console = SadConsole.Console;

namespace WorldBuilder.Data.Backend
{
    public static class MethodExtensions
    {
        public static void Print(this Console console, int row, string text)
        {
            int col = (Program.Width - text.Length) / 2;
            console.Print(col, row, text);
        }

        public static void Print(this Console console, int row, string text, Color color)
        {
            int col = (Program.Width - text.Length) / 2;
            console.Print(col, row, text, color);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using SadConsole;
using Console = SadConsole.Console;

namespace WorldBuilder.Backend
{
    public static class MethodExtensions
    {
        public static void Print(this Console console, int row, string text)
        {
            int col = (Program.width - text.Length) / 2;
            console.Print(col, row, text);
        }

        public static void Print(this Console console, int row, string text, Color color)
        {
            int col = (Program.width - text.Length) / 2;
            console.Print(col, row, text, color);
        }
    }
}

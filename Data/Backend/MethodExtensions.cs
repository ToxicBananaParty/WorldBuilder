using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SadConsole;
using Console = SadConsole.Console;
using Game = SadConsole.Game;

namespace WorldBuilder.Data.Backend
{
    public static class MethodExtensions
    {
        public static void Print(this Console console, int row, string text)
        {
            int col = (Program.Width - text.Length) / 2;
			
			if(col < 0)
				col = 0;
			
            console.Print(col, row, text);
        }

        public static void Print(this Console console, int row, string text, Color color)
        {
            int col = (Program.Width - text.Length) / 2;
			
			if(col < 0)
				col = 0;
			
            console.Print(col, row, text, color);
        }

        public static void PrintRow(this Console console, int row, string text)
        {
	        for (int i = 0; i < Program.Width; i++)
	        {
		        console.Print(i, row, text);
	        }
        }

        public static void PrintRow(this Console console, int row, string text, Color color)
        {
	        for (int i = 0; i < Program.Width; i++)
	        {
		        console.Print(i, row, text, color);
	        }
        }
    }
}
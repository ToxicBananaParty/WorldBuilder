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

        public static string Print(this Gender gender)
        {
	        switch (gender)
	        {
		        case Gender.CisFemale:
			        return "Cis Female";
		        case Gender.CisMale:
			        return "Cis Male";
		        case Gender.NonBinary:
			        return "Non-Binary";
		        case Gender.TransMale:
			        return "Trans Male";
		        case Gender.TransFemale:
			        return "Trans Female";
		        default:
			        return "ERROR IN GENDER PRINT";
	        }
        }
    }
}
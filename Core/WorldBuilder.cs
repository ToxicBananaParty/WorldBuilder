using WorldBuilder.Data;
using WorldBuilder.Data.Backend;
using SadConsole;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SadConsole.Controls;
using Game = SadConsole.Game;

namespace WorldBuilder.Core
{
    public static class WorldBuilder
    {
        public static World instance;
        
        private static Console console;

        public static void Load(World toPlay)
        {
            instance = toPlay;
            console = Program.console;
            console.Clear();
            HomeScreen();
        }

        private static void HomeScreen()
        {
            int xOffset = 0;
            
            console.Print(32, 1, "World: [c:r f:Gray]" + instance.name);
            console.Print(32, 2, "Date: [c:r f:Gray]" + instance.date.ToShortDateString());
            xOffset = 23 + instance.name.Length;
            System.Console.WriteLine(instance.name.Length);
            
            console.Print(xOffset, 0, "[c:r f:White]Number of Characters: [c:r f:Gray]" + instance.characters.Count);
            console.Print(xOffset, 1, "[c:r f:White]Number of Locations: [c:r f:Gray]" + instance.locations.Count);
            console.Print(xOffset, 2, "[c:r f:White]Number of Organizations: [c:r f:Gray]" + instance.organizations.Count);
            console.Print(xOffset, 3, "[c:r f:White]Number of Historical Events: [c:r f:Gray]" + instance.events.Count);
            console.PrintRow(4, "=");
            
            console.PrintRow(30, "=");
        }
    }
}
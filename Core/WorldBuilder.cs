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
            Game.OnUpdate = HomeScreenInput;
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
            console.Print(36, 31, "V - View Random Character");
            console.Print(36, 32, "B - View Random Event");
            console.Print(36, 33, "N - View Random Location");
            console.Print(36, 34, "M - View Random Organization");
        }

        private static void DisplayCharacter(Character character)
        {
            console.Print(8, character.name);
            console.Print(10, "Born: " + character.birthdate.ToShortDateString());
            console.Print(12, "Location: " + character.homeBase.name);
            console.Print(14, "Gender: " + character.gender.Print());
        }

        private static void HomeScreenInput(GameTime time)
        {
            if (Global.KeyboardState.IsKeyPressed(Keys.V))
            {
                console.Clear(new Rectangle(0, 5, Program.Width, 24));
                DisplayCharacter(instance.characters[Program.RandomInt(instance.characters.Count)]);
            }
        }
    }
}
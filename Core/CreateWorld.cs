using System;
using WorldBuilder.Data.Backend;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SadConsole;
using WorldBuilder.Data;
using Game = SadConsole.Game;
using Console = SadConsole.Console;

namespace WorldBuilder.Core
{
    public static class CreateWorld
    {
        private static Console console;
        
        private static string worldName;
        private static int worldAge;
        private static World world;
        
        public static void Start()
        {
            //TODO: Un-center all this
            console = Program.console;

            console.Print(3, "Enter World Name: ");
            console.Cursor.IsEnabled = true;
            console.Cursor.IsVisible = true;
            console.Cursor.Position = new Point(55, 6);
            Game.OnUpdate = GetWorldName;
        }

        private static void GetWorldName(GameTime time)
        {
            if (Global.KeyboardState.IsKeyPressed(Keys.Enter))
            { 
                worldName = console.GetString(55, 6, Program.Width - 55);
                worldName = worldName.Substring(0, 30);

                System.Console.WriteLine(worldName);
                for (int i = 55; i < Program.Width; i++)
                    console.SetForeground(i, 6, Color.Gray);
                

                console.Cursor.Position = new Point(60, 13);
                console.Print(10, "How many years of history to pre-generate? Enter a number 0 - 100");
                Game.OnUpdate = GetStartDate;
            }
        }

        private static void GetStartDate(GameTime time)
        {
            if (Global.KeyboardState.IsKeyPressed(Keys.Enter))
            {
                worldAge = int.Parse(console.GetString(60, 13, Program.Width - 60));
                System.Console.WriteLine(worldAge);
                for(int i = 60; i < Program.Width; i++)
                    console.SetForeground(i, 13, Color.Gray);

                console.Cursor.IsVisible = false;
                console.Cursor.IsEnabled = false;

                world = new World(worldName);
                world.AdvanceDays(worldAge * 365, true);
                world.setDate(new DateTime(worldAge, 1, 1));
                WorldBuilder.Load(world);
            }
        }
    }
}
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SadConsole;
using WorldBuilder.Backend;
using WorldBuilder.Core;
using Console = SadConsole.Console;
using Game = SadConsole.Game;

namespace WorldBuilder
{
    class Program
    {
        public static readonly int width = 128, height = 32;
        public static Console console;

        static void Main(string[] args)
        {
            Game.Create(width, height);
            Game.OnInitialize = Init;
            Game.OnUpdate = Update;

            Game.Instance.Run();
            Game.Instance.Dispose();
        }

        static void Init()
        {
            console = new Console(width, height);
            Global.CurrentScreen = console;

            console.Print(3, "WorldBuilder");
            console.Print(6, "v1.0 Copyright (C) 2020, Ryan Dwyer");
            console.Print(8, "A Ryan Dwyer Production");
            console.Print(10, "www.rydwy.com");

            console.Print(14, "Press ESC now to quit. Quitting later causes your progress to be saved.");
            console.Print(16, "Press any other key to continue!");
        }

        static void Update(GameTime time)
        {
            if(Global.KeyboardState.IsKeyReleased(Keys.Escape))
                Game.Instance.Exit();
            else if(Global.KeyboardState.KeysPressed.Count > 0)
                FirstPrompt.Start(console);
        }
    }

    class FirstPrompt
    {
        private static Console console;

        public static void Start(Console c)
        {
            console = c;
            console.Clear();
            console.Print(5, "Create a New World, or Load an Old World?");
            console.Print(44, 20, "A) New Game");
            console.Print(70, 20, "B) Load Game");

            Game.OnUpdate = Update;
        }

        public static void Update(GameTime time)
        {
            if (Global.KeyboardState.IsKeyPressed(Keys.A))
            {
                NewWorld.Create(console);
            }
            else if (Global.KeyboardState.IsKeyPressed(Keys.B))
            {

            }
        }
    }
}

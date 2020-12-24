using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using SadConsole;
using SadConsole.Input;
using WorldBuilder.Data;
using WorldBuilder.Data.Backend;
using Console = SadConsole.Console;
using Game = SadConsole.Game;
using Keyboard = SadConsole.Input.Keyboard;

namespace WorldBuilder
{
    static class Program
    {
        public const int Width = 128;
        public const int Height = 36;

        public static Console console;
        private static Random rand;
        private static List<World> savedWorlds;

        static void Main(string[] args)
        {
            rand = new Random(DateTime.Now.Millisecond);
            NameGenerator.NameList list = new NameGenerator.NameList();

            // Setup the engine and create the main window.
            SadConsole.Game.Create(Width, Height);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Start the game.
            SadConsole.Game.Instance.Run();
            SadConsole.Game.Instance.Dispose();
        }

        public static int RandomInt(int max)
        {
            return rand.Next(max);
        }

        public static int RandomInt(int min, int max)
        {
            return rand.Next(min, max);
        }

        private static void loadNames()
        {
            NameGenerator.NameList instance = new NameGenerator.NameList();

            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader reader = new StreamReader("..//..//..//Data//Backend//names.json"))
            using (JsonReader jreader = new JsonTextReader(reader))
            {
                NameGenerator.instance = instance = serializer.Deserialize<NameGenerator.NameList>(jreader);
            }
        }

        private static void Init()
        {
            loadNames();

            console = Global.CurrentScreen;
            console.Clear();
            console.UsePrintProcessor = true;

            console.Print(6, "WorldBuilder v1.0");
            console.Print(8, "By Ryan Dwyer");

            console.Print(15, "Press ESC to Quit");
            console.Print(16, "Press any other key to Continue");
            Game.OnUpdate = UpdateSplashScreen;
            console.IsFocused = true;
        }

        private static void UpdateSplashScreen(GameTime time)
        {
            if (Global.KeyboardState.IsKeyPressed(Keys.Escape))
                Game.Instance.Exit();
            else if (Global.KeyboardState.KeysPressed.Count > 0)
            {
                console.Clear();
                LoadWorld();
                Game.OnUpdate -= UpdateSplashScreen;
            }
        }

        private static void LoadWorld()
        {
            console.Print(1, "Saved Worlds");
            console.PrintRow(2, "=");
            
            //TODO: Find saved worlds
            savedWorlds = new List<World>();
            World world = new World("Test World");
            savedWorlds.Add(world);

            int row = 4;
            for (int i = 0; i < savedWorlds.Count; i++, row += 2)
            {
                console.Print(1, row, (i+1) + ". " + savedWorlds[i].name);
            }
            
            console.Print(1, row, savedWorlds.Count + 1 + ". New World");
            Game.OnUpdate = UpdateLoadWorld;
        }

        private static void UpdateLoadWorld(GameTime time)
        {
            if (Global.KeyboardState.KeysPressed.Count > 0)
            {
                AsciiKey pressed = Global.KeyboardState.KeysPressed[0];
                if (Char.IsNumber(pressed.Character))
                {
                    int worldToLoad = pressed.Character - 48;
                    //System.Console.WriteLine(worldToLoad);
                    if (worldToLoad <= savedWorlds.Count)
                    {
                        console.Clear();
                        Game.OnUpdate -= UpdateLoadWorld;
                        Core.WorldBuilder.Load(savedWorlds[worldToLoad - 1]);
                    }
                    else if (worldToLoad == savedWorlds.Count + 1)
                    {
                        console.Clear();
                        Game.OnUpdate -= UpdateLoadWorld;
                        Core.CreateWorld.Start();
                    }
                }
            }
        }
    }
}
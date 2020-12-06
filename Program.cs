using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using SadConsole;
using WorldBuilder.Data;
using WorldBuilder.Data.Backend;
using Console = SadConsole.Console;

namespace WorldBuilder
{
    static class Program
    {
        public const int Width = 128;
        public const int Height = 36;

        public static Console console;
        private static Random rand;

        static void Main(string[] args)
        {
            rand = new Random(DateTime.Now.Millisecond);
            NameGenerator.NameList list = new NameGenerator.NameList();
            
            // Setup the engine and create the main window.
            SadConsole.Game.Create(Width, Height);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;
            SadConsole.Game.OnUpdate += Update;

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
            using(StreamReader reader = new StreamReader("..//..//..//Data//Backend//names.json"))
            using (JsonReader jreader = new JsonTextReader(reader)) {
                NameGenerator.instance = instance = serializer.Deserialize<NameGenerator.NameList>(jreader);
            }
        }

        private static void Init()
        {
            loadNames();
            
            console = Global.CurrentScreen;
            console.FillWithRandomGarbage();
            console.Fill(new Rectangle(3, 3, 27, 5), null, Color.Black, 0, SpriteEffects.None);
            console.Print(6, 5, "Hello from SadConsole", ColorAnsi.CyanBright);
        }

        private static void Update(GameTime time)
        {
            if (Global.KeyboardState.IsKeyPressed(Keys.F)) {
                console.Clear();
                console.Print(6, 5, NameGenerator.GenerateHuman(Gender.RANDOM));
            }
        }
    }
}
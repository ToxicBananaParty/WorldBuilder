using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SadConsole;
using WorldBuilder.Data.Backend;

namespace WorldBuilder
{
    static class Program
    {
        public const int Width = 128;
        public const int Height = 36;

        private static Random rand;
        private static NameGenerator nameGenerator;

        static void Main(string[] args)
        {
            rand = new Random(DateTime.Now.Millisecond);
            nameGenerator = new NameGenerator();
            
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

        private static void Init()
        {
            var startingConsole = SadConsole.Global.CurrentScreen;
            startingConsole.FillWithRandomGarbage();
            startingConsole.Fill(new Rectangle(3, 3, 27, 5), null, Color.Black, 0, SpriteEffects.None);
            startingConsole.Print(6, 5, "Hello from SadConsole", ColorAnsi.CyanBright);
        }

        private static void Update(GameTime time)
        {
            if (Global.KeyboardState.IsKeyPressed(Keys.F)) {
                Global.CurrentScreen.Clear();
                Global.CurrentScreen.Print(6, 5, nameGenerator.GenerateHuman(Gender.CisMale));
            }
        }
    }
}
using System;
using Microsoft.Xna.Framework;
using SadConsole;
using WorldBuilder.Backend;
using Console = SadConsole.Console;
using Game = SadConsole.Game;

namespace WorldBuilder
{
    class Program
    {
        public static readonly int width = 112, height = 32;

        static void Main(string[] args)
        {
            Game.Create(width, height);
            Game.OnInitialize = Init;

            Game.Instance.Run();
            Game.Instance.Dispose();
        }

        static void Init()
        {
            var console = new Console(width, height);
            //console.FillWithRandomGarbage();
            //console.Fill(new Rectangle(3, 3, 23, 3), Color.Violet, Color.Black, 0, 0);
            console.Print(4, "Hello World!", Color.Aqua);

            Global.CurrentScreen = console;
        }
    }
}

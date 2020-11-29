using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SadConsole;
using WorldBuilder.Backend;
using WorldBuilder.Data;
using Console = SadConsole.Console;
using Game = SadConsole.Game;

namespace WorldBuilder.Core
{ //Static Stuff
    public class NewWorld
    {
        public static Console console;

        private static StringBuilder newWorldName;

        public static void Create(Console c = null)
        {
            newWorldName = new StringBuilder();
            if (c != null)
                console = c;

            console.Clear();
            console.Print(7, "What will you name this world?");
            console.IsFocused = true;
            console.Cursor.IsVisible = true;
            console.Cursor.Move(60, 12);
            Game.Instance.Window.TextInput += Create_GetWorldName;

        }

        private static void Create_GetWorldName(object sender, TextInputEventArgs e)
        {
            if (e.Key == Keys.Back && newWorldName.Length > 0)
                newWorldName.Remove(newWorldName.Length - 1, 1);
            else if (e.Key == Keys.Enter)
            {
                System.Console.WriteLine(newWorldName.ToString());
                World world = new World(newWorldName.ToString());
                Game.Instance.Window.TextInput -= Create_GetWorldName;
                console.Cursor.IsVisible = false;
                console.Cursor.IsEnabled = false;
                console.Clear();
                console.SwitchWorld(world);
            }
            else
                newWorldName.Append(e.Character);
        }
    }
}
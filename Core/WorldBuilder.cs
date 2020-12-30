using System.Collections.Generic;
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
            
            if (NameGenerator.usedCityNames == null || NameGenerator.usedCityNames.Count < 1)
            {
                NameGenerator.usedCityNames = new List<string>();
                foreach (Location loc in instance.locations)
                    if(loc.type == LocationType.City)
                        NameGenerator.usedCityNames.Add(loc.name);
            }
            
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
        
        //TODO Selection Menus (Update methods) for each of these Display methods

        private static void DisplayCharacter(Character character)
        {
            console.Print(8, character.name);
            console.Print(10, "Born: " + character.birthdate.ToShortDateString());
            console.Print(12, "Location: " + character.homeBase.name);
            console.Print(14, "Gender: " + character.gender.Print());
        }

        private static void DisplayEvent(Event toDisplay)
        {
            console.Print(8, toDisplay.name);
            console.Print(10, "Happened On: " + toDisplay.date.ToShortDateString());
            console.Print(12, "Performer: " + toDisplay.performer.name);

            string performeeText = "";
            if (toDisplay.performee?.name == null)
                performeeText = "N/A";
            else
                performeeText = toDisplay.performee.name;
            console.Print(14, "Performee: " + performeeText);
        }

        private static void DisplayLocation(Location location)
        {
            console.Print(8, location.name);
            console.Print(10, location.type.ToString());

            int rowAdd = 12;
            foreach(KeyValuePair<Character, LocationRelationship> character in location.relatedChars)
            {
                if (character.Value == LocationRelationship.OwnerCaretaker) {
                    console.Print(rowAdd, "Owner/Caretaker: " + character.Key.name);
                    rowAdd += 2;
                }
            }

            console.Print(rowAdd, "Inhabitants:");
            rowAdd += 2;
            
            foreach (KeyValuePair<Character, LocationRelationship> character in location.relatedChars) {
                if (character.Value == LocationRelationship.Resident && rowAdd < 28) {
                    console.Print(rowAdd, character.Key.name);
                    rowAdd++;
                }
            }
            
        }

        private static void DisplayEvents()
        {
            for (int i = 5; i < 29; i++)
            {
                console.Print(i, instance.events[Program.RandomInt(instance.events.Count)].name);
            }
        }

        private static void HomeScreenInput(GameTime time)
        {
            if (Global.KeyboardState.IsKeyPressed(Keys.V))
            {
                console.Clear(new Rectangle(0, 5, Program.Width, 24));
                DisplayCharacter(instance.characters[Program.RandomInt(instance.characters.Count)]);
            }
            else if (Global.KeyboardState.IsKeyPressed(Keys.B))
            {
                console.Clear(new Rectangle(0, 5, Program.Width, 24));
                DisplayEvent(instance.events[Program.RandomInt(instance.events.Count)]);
            }
            else if (Global.KeyboardState.IsKeyPressed(Keys.N))
            {
                console.Clear(new Rectangle(0, 5, Program.Width, 24));
                DisplayLocation(instance.locations[Program.RandomInt(instance.locations.Count)]);
            }
        }
    }
}
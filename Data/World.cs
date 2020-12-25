using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using WorldBuilder.Data.Backend;

namespace WorldBuilder.Data
{
    public class World
    {
        public List<Character> characters { get; private set; }
        public List<Event> events { get; private set; }
        public List<Item> items { get; private set; }
        public List<Location> locations { get; private set; }
        public List<Organization> organizations { get; private set; }
        public DateTime date { get; private set; }

        public string name { get; private set; }
        
        public World(string name)
        {
            this.name = name;
            initStats();
        }

        public void AdvanceDay(bool newGame = false)
        {
            date = date.AddDays(1);
            //TODO: Any daily logic here

            if (newGame)
            {
                //Game will make chars, locations, etc from nothing more often in world generation stage
                //After that will make chars, locations, etc mostly from existing chars, locations, etc.
                MakeSomething();
            }
            else
            {
                
            }
        }

        public void AdvanceDays(int numDays, bool newGame)
        {
            for(int i = 0; i < numDays; i++)
                AdvanceDay(newGame);
        }

        private void initStats()
        {
            characters = new List<Character>();
            events = new List<Event>();
            items = new List<Item>();
            locations = new List<Location>();
            organizations = new List<Organization>();
            date = new DateTime(1, 1, 1);
        }

        private void MakeSomething()
        {
            //TODO: Give relations to current chars, orgs, locations
            
            int thingToDo = Program.RandomInt(0, 40);
            if (thingToDo < 3)
            {
                //TODO: Do not make a Location of LocationType if all its names are used
                Location newLoc = new Location();
                locations.Add(newLoc);
            }
            else if (thingToDo < 11)
            {
                Character newChar = new Character();
                
                if(locations.Count > 5)
                    newChar.SetHomeBase(locations[Program.RandomInt(locations.Count)]);
                else
                    newChar.SetHomeBase(new Location());
                
                characters.Add(newChar);
            }
            else if (thingToDo < 39)
            {
                //New Event
                if (characters.Count < 5 || locations.Count < 2)
                    return;

                Event eve = new Event(characters[Program.RandomInt(characters.Count)]);
                events.Add(eve);
            }
            else
            {
                //New Organization
                if (characters.Count < 30 || locations.Count < 50)
                    return;

                Location hq = null;
                do
                {
                    hq = locations[Program.RandomInt(locations.Count)];
                } while (hq.type != LocationType.City && hq.type != LocationType.Temple &&
                         hq.type != LocationType.Town);

                Organization org = new Organization(hq);
                organizations.Add(org);
            }
        }
        
        #region Accessors and Mutators
        
        public void setName(string name)
        {
            this.name = name;
        }

        public void AddCharacter(Character toAdd)
        {
            characters.Add(toAdd);
        }

        public void DeleteCharacter(Character toDelete)
        {
            characters.Remove(toDelete);
        }

        public void AddLocation(Location toAdd)
        {
            locations.Add(toAdd);
        }

        public void DeleteLocation(Location toDelete)
        {
            locations.Remove(toDelete);
        }

        public void AddItem(Item toAdd)
        {
            items.Add(toAdd);
        }

        public void DeleteItem(Item toDelete)
        {
            items.Remove(toDelete);
        }

        public void AddOrganization(Organization toAdd)
        {
            organizations.Add(toAdd);
        }

        public void DeleteOrganization(Organization toDelete)
        {
            organizations.Remove(toDelete);
        }

        public void AddEvent(Event toAdd)
        {
            events.Add(toAdd);
        }

        public void DeleteEvent(Event toDelete)
        {
            events.Remove(toDelete);
        }

        public void setDate(DateTime toSet)
        {
            date = toSet;
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
        
        public World()
        {
            initStats();
        }

        public void AdvanceDay()
        {
            date = date.AddDays(1);
            //TODO: Any daily logic here
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
        #endregion
    }
}
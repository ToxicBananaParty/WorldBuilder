using System;
using System.Collections.Generic;
using WorldBuilder.Data.Backend;

namespace WorldBuilder.Data
{
    public class Location : IEquatable<Location>
    {
        public string name { get; private set; }
        public LocationType type { get; private set; }
        public Dictionary<Character, LocationRelationship> relatedChars;
        //TODO: Nearby locations or some sort of radius so characters dont interact with people/places far away

        public Location()
        {
            //TODO: Generate Name
            type = (LocationType) Program.RandomInt((int) LocationType.NUM_TYPES);
            relatedChars = new Dictionary<Character, LocationRelationship>();
            relatedChars.Add(new Character(), LocationRelationship.OwnerCaretaker);
        }

        public Location(string name)
        {
            this.name = name;
            type = (LocationType) Program.RandomInt((int) LocationType.NUM_TYPES);
            relatedChars = new Dictionary<Character, LocationRelationship>();
            relatedChars.Add(new Character(), LocationRelationship.OwnerCaretaker);
        }

        public Location(string name, LocationType type)
        {
            this.name = name;
            this.type = type;
            relatedChars = new Dictionary<Character, LocationRelationship>();
            relatedChars.Add(new Character(), LocationRelationship.OwnerCaretaker);
        }

        public bool Equals(Location other)
        {
            if(other?.name == null)
                throw new ArgumentException();
            
            return name == other.name;
        }
    }
}
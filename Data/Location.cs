using System;
using System.Collections.Generic;
using WorldBuilder.Data.Backend;

namespace WorldBuilder.Data
{
    public class Location : IEquatable<Location>
    {
        public static bool allCityNamesUsed, allTownNamesUsed, allVillageNamesUsed;
        
        public World world { get; private set; }
        public string name { get; private set; }
        public LocationType type { get; private set; }
        public Dictionary<Character, LocationRelationship> relatedChars;
        //TODO: Nearby locations or some sort of radius so characters dont interact with people/places far away

        public Location()
        {
            type = generateType();
            relatedChars = new Dictionary<Character, LocationRelationship>();
            relatedChars.Add(new Character(), LocationRelationship.OwnerCaretaker);
            world = Core.WorldBuilder.instance;
            name = GenerateName();
        }

        public Location(string name)
        {
            this.name = name;
            type = generateType();
            relatedChars = new Dictionary<Character, LocationRelationship>();
            relatedChars.Add(new Character(), LocationRelationship.OwnerCaretaker);
            world = Core.WorldBuilder.instance;
        }

        public Location(string name, LocationType type)
        {
            this.name = name;
            this.type = type;
            relatedChars = new Dictionary<Character, LocationRelationship>();
            relatedChars.Add(new Character(), LocationRelationship.OwnerCaretaker);
            world = Core.WorldBuilder.instance;
        }

        public bool Equals(Location other)
        {
            if(other?.name == null)
                throw new ArgumentException();
            
            return name == other.name;
        }

        private string GenerateName()
        {
            //TODO: Case for every LocationType
            switch (type)
            {
                case LocationType.City:
                    return NameGenerator.GenerateCity();
                case LocationType.Town:
                    return NameGenerator.GenerateTown();
                case LocationType.Village:
                    return "DEBUG_Village";
                case LocationType.Dungeon:
                    return "DEBUG_Dungeon";
                case LocationType.Temple:
                    return "DEBUG_Temple";
                case LocationType.GeographicalFeature:
                    return "DEBUG_GeographicalFeature";
                default:
                    return "ERROR IN GENERATENAME SWITCH";
            }
        }

        private LocationType generateType()
        {
            LocationType output;
            do
            {
                output = (LocationType) Program.RandomInt((int) LocationType.NUM_TYPES);
            } while ((output == LocationType.City && allCityNamesUsed)
                     || (output == LocationType.Town && allTownNamesUsed)
                     || (output == LocationType.Village && allVillageNamesUsed));

            return output;
        }
    }
}
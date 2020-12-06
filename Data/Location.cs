using System;

namespace WorldBuilder.Data
{
    public class Location : IEquatable<Location>
    {
        public string name { get; private set; }

        public bool Equals(Location other)
        {
            if(other?.name == null)
                throw new ArgumentException();
            
            return name == other.name;
        }
    }
}
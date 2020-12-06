using System;

namespace WorldBuilder.Data
{
    public class Event : IEquatable<Event>
    {
        public string name { get; private set; }
        
        public bool Equals(Event other)
        {
            if(other?.name == null)
                throw new ArgumentException();

            return name == other.name;
        }
    }
}
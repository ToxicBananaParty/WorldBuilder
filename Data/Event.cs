using System;
using WorldBuilder.Data.Backend;

namespace WorldBuilder.Data
{
    public class Event : IEquatable<Event>
    {
        public string name { get; private set; }
        public EventType type { get; private set; }
        public Character performer { get; private set; }
        public Character performee { get; private set; }

        public Event()
        {
            //TODO: Event name generator
        }

        public bool Equals(Event other)
        {
            if(other?.name == null)
                throw new ArgumentException();

            return name == other.name;
        }
    }
}
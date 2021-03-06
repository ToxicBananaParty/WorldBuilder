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
        public World world { get; private set; }
        public DateTime date { get; private set; }

        public Event(Character performer)
        {
            this.performer = performer;
            world = Core.WorldBuilder.instance;
            date = world.date;
            type = (EventType) Program.RandomInt((int) EventType.NUM_EVENT_TYPES);
            name = getName();
        }

        public Event(Character performer, EventType type)
        {
            this.performer = performer;
            this.type = type;
            world = Core.WorldBuilder.instance;
            date = world.date;
            name = getName();
        }

        public Event(Character performer, Character performee)
        {
            this.performer = performer;
            this.performee = performee;
            world = Core.WorldBuilder.instance;
            date = world.date;
            type = (EventType) Program.RandomInt((int) EventType.NUM_EVENT_TYPES);
            name = getName();
        }
        
        public Event(Character performer, Character performee, EventType type)
        {
            this.performer = performer;
            this.performee = performee;
            this.type = type;
            world = Core.WorldBuilder.instance;
            date = world.date;
            name = getName();
        }

        private string getName()
        {
            //TODO: Implement full event name generator
            switch (type)
            {
                case EventType.Birth:
                    return performer.name + " was born";
                default:
                    return "DEBUG_EVENTNAME";
            }
        }

        public bool Equals(Event other)
        {
            if(other?.name == null)
                throw new ArgumentException();

            return name == other.name;
        }
    }
}
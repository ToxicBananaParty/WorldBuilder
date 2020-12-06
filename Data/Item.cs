using System;
using WorldBuilder.Data.Backend;

namespace WorldBuilder.Data
{
    public class Item : IEquatable<Item>
    {
        public string name { get; private set; }
        public ItemType type { get; private set; }

        public Item()
        {
            //TODO: Item name generator
            type = (ItemType) Program.RandomInt((int) ItemType.NUM_ITEMTYPES);
        }

        public Item(ItemType type)
        {
            //TODO: Item name generator
            this.type = type;
        }

        public Item(string name, ItemType type)
        {
            this.name = name;
            this.type = type;
        }
        
        public bool Equals(Item other)
        {
            if(other?.name == null || other?.type == null)
                throw new ArgumentException();

            return name == other.name && type == other.type;
        }
    }
}
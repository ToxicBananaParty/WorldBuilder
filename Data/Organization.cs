using System;

namespace WorldBuilder.Data
{
    public class Organization : IEquatable<Organization>
    {
        public string name { get; private set; }
        public Location headquarters { get; private set; }
        
        public World world { get; private set; }

        public Organization(string name, Location headquarters)
        {
            this.name = name;
            this.headquarters = headquarters;
            world = Core.WorldBuilder.instance;
        }

        public Organization(Location headquarters)
        {
            //TODO: Generate name
            this.headquarters = headquarters;
            world = Core.WorldBuilder.instance;
        }

        #region Accessors and Mutators

        public bool Equals(Organization other)
        {
            if(other?.name == null) 
                throw new ArgumentException();

            return name == other.name && headquarters == other.headquarters;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        
        public void setHQ(Location newHQ)
        {
            this.headquarters = newHQ;
        }
        #endregion
    }
}
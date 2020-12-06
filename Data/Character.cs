using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using WorldBuilder.Data.Backend;
using Attribute = WorldBuilder.Data.Backend.Attribute;

namespace WorldBuilder.Data
{
    public class Character : IEquatable<Character>
    {
        public string name { get; private set; }
        public Dictionary<Attribute, int> attributes { get; private set; }
        public DateTime birthdate { get; private set; }
        public DateTime deathdate { get; private set; }
        public Race race { get; private set; }
        public Gender gender { get; private set; }

        private World myWorld;
        private bool alive;

        public Character()
        {
            //TODO: Generate birthdate
            gender = (Gender) Program.RandomInt((int) Gender.NUM_GENDERS);
            race = (Race) Program.RandomInt((int) Race.NUM_RACES);
            generateName(race);
            initStats();
        }

        public Character(Gender gender)
        {
            //TODO: Generate birthdate
            this.gender = gender;
            race = (Race) Program.RandomInt((int) Race.NUM_RACES);
            generateName(race);
            initStats();
        }

        public Character(string name, Gender gender)
        {
            //TODO: Generate birthdate
            this.name = name;
            this.gender = gender;
            race = (Race) Program.RandomInt((int) Race.NUM_RACES);
            initStats();
        }

        public Character(string name, Gender gender, Race race)
        {
            //TODO: Generate birthdate
            this.name = name;
            this.gender = gender;
            this.race = race;
            initStats();
        }

        private void initStats()
        {
            myWorld = Core.WorldBuilder.instance;
            alive = true;
            attributes = new Dictionary<Attribute, int>((int)Attribute.NUM_ATTRIBUTES);
            attributes.Add(Attribute.Strength, 0);
            attributes.Add(Attribute.Dexterity, 0);
            attributes.Add(Attribute.Intelligence, 0);
            attributes.Add(Attribute.Charisma, 0);
            attributes.Add(Attribute.Constitution, 0);
        }

        private void generateName(Race race)
        {
            //TODO: The rest of the races
            switch (race) {
                case(Race.Human):
                    name = NameGenerator.GenerateHuman(gender);
                    break;
                default:
                    break;
            }
        }
        
        #region Static Methods

        public static int getGender(Character toCheck)
        {
            return getGender(toCheck.gender);
        }

        public static int getGender(Gender toCheck)
        {
            if (toCheck == Gender.CisFemale || toCheck == Gender.TransFemale)
                return -1;

            if (toCheck == Gender.NonBinary)
                return 0;
            
            if(toCheck == Gender.NUM_GENDERS || toCheck == Gender.RANDOM)
                throw new ArgumentException("Trying to getGender of NUM_GENDERS or RANDOM");

            return 1;
        }
        
        #endregion

        #region Accessors and Mutators

        public int getAge()
        {
            if(myWorld?.date == null)
                throw new NullReferenceException("Character " + name + "'s myWorld or myWorld's date is null");
            
            if(myWorld.date.Year < birthdate.Year)
                throw new InvalidDataException("Character " + name + " somehow hasn't been born yet!");
            
            return myWorld.date.Year - birthdate.Year;
        }

        public void changeGender()
        {
            if (getGender(this) > 0)
                this.gender = Gender.TransFemale;
            else
                this.gender = Gender.TransMale;
        }

        public void setRace(Race toSet)
        {
            race = toSet;
        }

        public void changeAttribute(Attribute toChange, int amount)
        {
            attributes[toChange] += amount;
        }

        public void setAttribute(Attribute toSet, int value)
        {
            attributes[toSet] = value;
        }

        public void Kill()
        {
            alive = false;
            deathdate = myWorld.date;
        }

        public bool Equals(Character other)
        {
            if (other?.name == null || other?.birthdate == null)
                throw new ArgumentException("Character 'other' is null or birthdate or name is null!");

            return name == other.name && birthdate.Equals(other.birthdate);
        }
        #endregion
    }
}
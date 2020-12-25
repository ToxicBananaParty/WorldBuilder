using System;
using System.Collections;
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
        public Dictionary<Character, CharacterRelationship> relatedChars { get; private set; }
        public Location homeBase { get; private set; } //TODO: Implement this
        public World world { get; private set; }

        private World myWorld;
        private bool alive;

        public Character()
        {
            gender = (Gender) Program.RandomInt((int) Gender.NUM_GENDERS);
            race = (Race) Program.RandomInt((int) Race.NUM_RACES);
            generateName(race);
            initStats();
        }

        public Character(Gender gender)
        {
            this.gender = gender;
            race = (Race) Program.RandomInt((int) Race.NUM_RACES);
            generateName(race);
            initStats();
        }

        public Character(DateTime birthdate)
        {
            gender = (Gender) Program.RandomInt((int) Gender.NUM_GENDERS);
            race = (Race) Program.RandomInt((int) Race.NUM_RACES);
            generateName(race);
            initStats(true);
            this.birthdate = birthdate;
        }

        public Character(Gender gender, Race race)
        {
            this.gender = gender;
            this.race = race;
            generateName(race);
            initStats();
        }

        public Character(string name, Gender gender)
        {
            this.name = name;
            this.gender = gender;
            race = (Race) Program.RandomInt((int) Race.NUM_RACES);
            initStats();
        }

        public Character(string name, Gender gender, Race race)
        {
            this.name = name;
            this.gender = gender;
            this.race = race;
            initStats();
        }

        public void HaveChild()
        {
            Character partner = null;
            foreach (KeyValuePair<Character, CharacterRelationship> relatedChar in relatedChars)
            {
                if (relatedChar.Value == CharacterRelationship.Lover ||
                    relatedChar.Value == CharacterRelationship.Spouse)
                    partner = relatedChar.Key;
            }

            if (partner == null)
            {
                //TODO: Get partner from nearby related chars
            }

            Character child = new Character(Gender.RANDOM, race);
            relatedChars.Add(child, CharacterRelationship.Child);
            child.AddRelatedChar(this, CharacterRelationship.Parent);
            child.AddRelatedChar(partner, CharacterRelationship.Parent);
        }

        private void initStats(bool hasBirthDate = false)
        {
            myWorld = Core.WorldBuilder.instance;
            alive = true;
            attributes = new Dictionary<Attribute, int>((int)Attribute.NUM_ATTRIBUTES);
            attributes.Add(Attribute.Strength, 0);
            attributes.Add(Attribute.Dexterity, 0);
            attributes.Add(Attribute.Intelligence, 0);
            attributes.Add(Attribute.Charisma, 0);
            attributes.Add(Attribute.Constitution, 0);
            
            if(gender == Gender.RANDOM)
                gender = (Gender)Program.RandomInt((int)Gender.NUM_GENDERS);

            world = Core.WorldBuilder.instance;
            
            if(!hasBirthDate)
                birthdate = world.date;
            
            world.AddEvent(new Event(this, EventType.Birth));
        }

        private void generateName(Race race)
        {
            //TODO: The rest of the races
            switch (race) {
                case(Race.Human):
                    name = NameGenerator.GenerateHuman(gender);
                    break;
                default:
                    name = NameGenerator.GenerateHuman(gender);
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

        public void AddRelatedChar(Character toAdd, CharacterRelationship rel)
        {
            relatedChars.Add(toAdd, rel);
        }

        public void RemoveRelatedChar(Character toRemove)
        {
            relatedChars.Remove(toRemove);
        }

        public void SetHomeBase(Location hq)
        {
            homeBase = hq;
        }

        public void ChangeBirthDate(DateTime newDate)
        {
            birthdate = newDate;
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
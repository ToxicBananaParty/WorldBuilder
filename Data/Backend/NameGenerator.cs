using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static WorldBuilder.Program;

namespace WorldBuilder.Data.Backend
{
    public static class NameGenerator
    {
        public static NameList instance;
        
        public static List<string> usedCityNames, usedTownNames;
        
        public static string GenerateHuman(Gender gender)
        {
            if(instance == null)
                throw new NullReferenceException("NameGenerator instance is null");

            if (gender == Gender.RANDOM) {
                gender = (Gender)RandomInt((int)Gender.NUM_GENDERS);
            }
            
            NameList.HumanName humanName = instance.humanName;
            string firstname, lastname;

            if (Character.getSex(gender) > 0) {
                firstname = humanName.male[RandomInt(humanName.male.Length)];
            }
            else if (Character.getSex(gender) < 0) {
                firstname = humanName.female[RandomInt(humanName.female.Length)];
            }
            else {
                List<string> firstNames = new List<string>();
                firstNames.AddRange(humanName.male);
                firstNames.AddRange(humanName.female);
                firstname = firstNames[RandomInt(firstNames.Count)];
            }

            lastname = humanName.surname[RandomInt(humanName.surname.Length)];

            return firstname + " " + lastname;
        }

        public static string GenerateCity()
        {
            if (instance == null)
                throw new NullReferenceException();

            if (usedCityNames == null)
                usedCityNames = new List<string>();

            string output = "";
            do
            {
                int cityToGet = RandomInt(instance.cityNames.Count);
                output = instance.cityNames[cityToGet];
            } while (usedCityNames.Contains(output));
            
            usedCityNames.Add(output);
            if (usedCityNames.Count == instance.cityNames.Count)
                Location.allCityNamesUsed = true;

            return output;
        }

        public static string GenerateTown()
        {
            if (instance == null)
                throw new NullReferenceException();

            if (usedTownNames == null)
                usedTownNames = new List<string>();

            string output = "";
            do {
                int townToGet = RandomInt(instance.townNames.Count);
                output = instance.townNames[townToGet];
            } while (usedTownNames.Contains(output));
            
            usedTownNames.Add(output);
            if (usedTownNames.Count == instance.townNames.Count)
                Location.allTownNamesUsed = true;

            return output;
        }

        //EXISTS ONLY TO BE READ FROM JSON
        //ALL LOGIC DONE IN NameGenerator CLASS
        public class NameList
        {
            [JsonProperty("human")]
            public HumanName humanName;

            [JsonProperty("city")] 
            public List<string> cityNames;

            [JsonProperty("town")] 
            public List<string> townNames;

            public NameList()
            {
                humanName = new HumanName();
                instance = this;
            }

            public class HumanName
            {
                public string[] male { get; set; }
                public string[] female { get; set; }
                public string[] surname { get; set; }

                public HumanName()
                {
                    male = new string[] { };
                    female = new string[] { };
                    surname = new string[] { };
                }
            }
        }
    }
}
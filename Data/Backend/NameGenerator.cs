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
        
        public static string GenerateHuman(Gender gender)
        {
            if(instance == null)
                throw new NullReferenceException("NameGenerator instance is null");

            if (gender == Gender.RANDOM) {
                gender = (Gender)RandomInt((int)Gender.NUM_GENDERS);
            }
            
            NameList.HumanName humanName = instance.humanName;
            string firstname, lastname;

            if (Character.getGender(gender) > 0) {
                firstname = humanName.male[RandomInt(humanName.male.Length)];
            }
            else if (Character.getGender(gender) < 0) {
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
        
        //EXISTS ONLY TO BE READ FROM JSON
        //ALL LOGIC DONE IN NameGenerator CLASS
        public class NameList
        {
            [JsonProperty("human")]
            public HumanName humanName;

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
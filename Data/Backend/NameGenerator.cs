using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WorldBuilder.Data.Backend
{
    public class NameGenerator
    {
        public class NameList
        {
            [JsonProperty("human")]
            public HumanName humanName;

            public NameList()
            {
                humanName = new HumanName();
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

                public string maleName(int index)
                {
                    return male[index];
                }

                public string femaleName(int index)
                {
                    return female[index];
                }

                public string lastName(int index)
                {
                    return surname[index];
                }
            }
        }

        private NameList nameList;
        
        public NameGenerator()
        {
            nameList = new NameList();
            
            JsonSerializer serializer = new JsonSerializer();
            //TODO: Find file
            using (StreamReader reader = new StreamReader("..//..//..//Data//Backend//names.json"))
            using (JsonReader jr = new JsonTextReader(reader)) {
                nameList = serializer.Deserialize<NameList>(jr);
            }
        }

        public string GenerateHuman(Gender gender)
        {
            //TODO Check gender
            string firstName =  nameList.humanName.male[Program.RandomInt(nameList.humanName.male.Length)];
            string lastName = nameList.humanName.lastName(Program.RandomInt(nameList.humanName.surname.Length));
            return firstName + " " + lastName;
        }
    }
}
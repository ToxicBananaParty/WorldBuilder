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

            private List<string> humanFirstNames;

            public NameList()
            {
                humanName = new HumanName();
                humanFirstNames = new List<string>();
            }
            
            public string humanmale(int index)
            {
                return humanName.male[index];
            }

            public string humanfemale(int index)
            {
                return humanName.female[index];
            }

            public string humanenby(int index)
            {
                if (humanFirstNames.Count < 1) {
                    humanFirstNames.AddRange(humanName.male);
                    humanFirstNames.AddRange(humanName.female);
                }

                return humanFirstNames[index];
            }

            public string humansurname(int index)
            {
                return humanName.surname[index];
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
        
        private static NameGenerator instance;

        public static string GenerateHuman(Gender gender)
        {
            if(instance == null)
                throw new NullReferenceException();
            
            return instance.getHuman(gender);
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

            instance = this;
        }

        private string getHuman(Gender gender)
        {
            //TODO Check gender
            string firstname = "", lastname = "";

            if (Character.getGender(gender) > 0) {
                //Male name
                firstname = nameList.humanmale(Program.RandomInt(nameList.humanName.male.Length));
            }
            else if (Character.getGender(gender) < 0) {
                //Female
                firstname = nameList.humanfemale(Program.RandomInt(nameList.humanName.male.Length));
            }
            else {
                //Nonbinary
                firstname = nameList.humanenby(Program.RandomInt(nameList.humanName.male.Length 
                                                                 + nameList.humanName.female.Length));
            }
            
            lastname = nameList.humansurname(Program.RandomInt(nameList.humanName.surname.Length));
            return firstname + " " + lastname;
        }
    }
}
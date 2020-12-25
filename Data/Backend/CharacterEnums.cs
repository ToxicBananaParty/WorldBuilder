namespace WorldBuilder.Data.Backend
{
    public enum Attribute
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Charisma,
        NUM_ATTRIBUTES
    }

    public enum Race
    {
        //TODO: Name generators for:
        //    2) Elf
        //    3) Dwarf
        //    4) Gnome
        //    5) Halfling
        //    6) HalfElf
        //    7) HalfOrc
        //    8) Tiefling
        //    9) Dragonborn
        Human,
        Elf,
        Dwarf,
        Gnome,
        Halfling,
        HalfElf,
        HalfOrc,
        Tiefling,
        Dragonborn,
        NUM_RACES
    }

    public enum CharacterRelationship
    {
        Friend,
        Enemy,
        Ally,
        Liege,
        Vassal,
        Nemesis,
        Lover,
        Spouse,
        Child,
        Parent,
        Sibling,
        Neighbor,
        NUM_RELATIONSHIPS
    }

    public enum Gender
    {
        CisMale,
        CisFemale,
        NonBinary,
        TransMale,
        TransFemale,
        NUM_GENDERS,
        RANDOM
    }
}
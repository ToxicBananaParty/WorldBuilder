namespace WorldBuilder.Data.Backend
{
    public enum LocationType
    {
        Village,
        Town,
        City,
        Temple,
        Dungeon,
        GeographicalFeature,
        NUM_TYPES
    }

    public enum LocationRelationship
    {
        OwnerCaretaker,
        Resident,
        Visitor
    }
}
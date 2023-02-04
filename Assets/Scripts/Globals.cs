using System.Collections.Generic;
using WorldTree;

public static class Globals
{

    public static int TERRAIN_LAYER_MASK = 1 << 6;
    public static Faction FACTION;


    //public static BuildingData[] BUILDING_DATA = {
    //  new BuildingData("House", 100),
    //new BuildingData("Tower", 50)
    // };
    public static List<UnitManager> UNITS = new List<UnitManager>();
    public static List<UnitManager> SELECTED_UNITS = new List<UnitManager>();
    
    public static Dictionary<string, GameResource> GAME_RESOURCES =
        new Dictionary<string, GameResource>()
        {
            { "mana", new GameResource("Mana", 300) }
        };
    
}
using WorldTree;

public class Globals
{

    public static int TERRAIN_LAYER_MASK = 1 << 6;


    public static BuildingData[] BUILDING_DATA = {
        new BuildingData("House", 100),
        new BuildingData("Tower", 50)
    };
}
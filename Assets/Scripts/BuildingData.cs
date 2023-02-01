public class BuildingData
{
    private string _code;
    private int _healthpoints;
    public BuildingData(string code, int healthpoints)
    {
        _code = code;
        _healthpoints = healthpoints;
    }
    
    public string Code { get; }

    public int HP { get; }
}
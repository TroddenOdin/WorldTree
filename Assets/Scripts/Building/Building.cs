using System.Collections.Generic;
using UnityEngine;
using WorldTree;


public enum BuildingPlacement
{
    Valid,
    Invalid,
    Fixed
};


public class Building
{
    private BuildingData _data;
    private Transform _transform;
    private int _currentHealth;
    private BuildingPlacement _placement;
    private List<Material> _materials;
    private BuildingManager _buildingManager;
    private BuildingPlacer _placer;
    

    public Building(BuildingData data, BuildingPlacer placer)
    {
        _data = data;
        _placer = placer;

        _currentHealth = data.healthpoints;

        GameObject g = GameObject.Instantiate(data.prefab) as GameObject;
        _transform = g.transform;

        _buildingManager = _transform.GetComponent<BuildingManager>();
        
        _materials = new List<Material>();
        foreach (Material material in _transform.Find("Mesh").GetComponent<Renderer>().materials)
        {
            _materials.Add(new Material(material));
        }
        
        _placement = BuildingPlacement.Valid;
        SetMaterials();
    }
    
    
    
    

    public void SetMaterials() { SetMaterials(_placement); }

    public void SetMaterials(BuildingPlacement placement)
    {
        List<Material> materials;
        if (placement == BuildingPlacement.Valid)
        {
            Material refMaterial = Resources.Load("Materials/Valid") as Material;
            materials = new List<Material>();
            for (int i = 0; i < _materials.Count; i++)
            {
                materials.Add(refMaterial);
            }
        }
        else if (placement == BuildingPlacement.Invalid)
        {
            Material refMaterial = Resources.Load("Materials/Invalid") as Material;
            materials = new List<Material>();
            for (int i = 0; i < _materials.Count; i++)
            {
                materials.Add(refMaterial);
            }
        }
        else if (placement == BuildingPlacement.Fixed)
        {
            materials = _materials;
        }
        else
        {
            return;
        }

        _transform.Find("Mesh").GetComponent<Renderer>().materials = materials.ToArray();
    }

    public void SetPosition(Vector3 position)
    {
        _transform.position = position;
    }
    
    public string Code { get => _data.code; }

    public Transform Transform { get => _transform; }

    public int HP { get => _currentHealth; set => _currentHealth = value; }
    

    public int MaxHP { get => _data.healthpoints; }

    public int DataIndex
    {
        get {
            for (int i = 0; i < _placer.buildings.Count; i++)
            {
                if (_placer.buildings[i].code == _data.code)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    public void Place()
    {
        //set placement state
        _placement = BuildingPlacement.Fixed;
        
        //change building materials
        SetMaterials();
        
        //remove "is trigger" to allow collision
        _transform.GetComponent<BoxCollider>().isTrigger = false;
    }

    public void CheckValidPlacement()
    {
        if (_placement == BuildingPlacement.Fixed) return;
        _placement = _buildingManager.CheckPlacement()
            ? BuildingPlacement.Valid
            : BuildingPlacement.Invalid;
    }

    public bool IsFixed => _placement == BuildingPlacement.Fixed;

    public bool HasValidPlacement { get => _placement == BuildingPlacement.Valid; }
    
    public bool CanBuy()
    {
        return _data.CanBuy(_placer.player.currentMana);
    }
}

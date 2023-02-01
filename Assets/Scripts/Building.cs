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
    

    public Building(BuildingData data)
    {
        GameObject g = GameObject.Instantiate(Resources.Load($"Prefabs/Buildings/{data.Code}")
        ) as GameObject;
        _transform = g.transform;

        _placement = BuildingPlacement.Valid;
        _buildingManager = g.GetComponent<BuildingManager>();
        _placement = BuildingPlacement.Valid;
        _data = data;
        _currentHealth = data.HP;
        _materials = new List<Material>();
        foreach (Material material in _transform.Find("Mesh").GetComponent<Renderer>().materials)
        {
            _materials.Add(new Material(material));
        }
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
    
    public string Code { get => _data.Code; }

    public Transform Transform { get => _transform; }

    public int HP { get => _currentHealth; set => _currentHealth = value; }
    

    public int MaxHP { get => _data.HP; }

    public int DataIndex
    {
        get
        {
            for (int i = 0; i < Globals.BUILDING_DATA.Length; i++)
            {
                if (Globals.BUILDING_DATA[i].Code == _data.Code)
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
}

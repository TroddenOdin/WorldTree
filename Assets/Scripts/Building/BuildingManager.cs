using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BuildingManager : UnitManager
{
    private BoxCollider _collider;

    private Building _building;
    private int _nCollisions;

    public void Initialize(Building building)
    {
        _collider = GetComponent<BoxCollider>();
        _building = building;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground") return;
        _nCollisions++;
        CheckPlacement();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground") return;

        _nCollisions--;
        CheckPlacement();
    }

    public bool CheckPlacement()
    {
        if (_building == null) return false;
        if (_building.IsFixed) return false;
        bool validPlacement = HasValidPlacement();

        if (!validPlacement)
        {
            _building.SetMaterials(BuildingPlacement.Invalid);
        }
        else
        {
            _building.SetMaterials(BuildingPlacement.Valid);
        }
        return validPlacement;
    }

    public bool HasValidPlacement()
    {
        return _nCollisions == 0;
    }
    
    protected override bool IsActive()
    {
        return _building.IsFixed;
    }
}
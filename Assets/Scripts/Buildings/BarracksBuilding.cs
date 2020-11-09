using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksBuilding : BuildingConstructor
{
    // Start is called before the first frame update
    void Start()
    {
        myType = buildingType.constructor;
        myClass = unitClass.heavy;
        armour = 2;
        evasion = 0;
        healthMax = 400;
        healthCurrent = healthMax;
        spawnPoint = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z -8);
    }

    public override void BuildingDestroyed()
    {
        base.BuildingDestroyed();
    }
    public override void CreateUnit()
    {
        base.CreateUnit();
        EnemyRoster.eR.garrisionedInfantry.Add(garrisonedUnit);
    }
}

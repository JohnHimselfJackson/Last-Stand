using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksBuilding : BuildingConstructor
{
    public List<GameObject> fire;

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

        fire[0].SetActive(false);
        fire[1].SetActive(false);
        fire[2].SetActive(false);
        fire[3].SetActive(false);
        fire[4].SetActive(false);
        fire[5].SetActive(false);
        fire[6].SetActive(false);
    }

    private void Update()
    {
        BaseUpdate();
        switch (damageState)
        {
            case DamageState.Healthy:
                fire[0].SetActive(false);
                fire[1].SetActive(false);
                fire[2].SetActive(false);
                fire[3].SetActive(false);
                fire[4].SetActive(false);
                fire[5].SetActive(false);
                fire[6].SetActive(false);
                break;
            case DamageState.Damaged:
                fire[0].SetActive(true);
                fire[1].SetActive(false);
                fire[2].SetActive(true);
                fire[3].SetActive(false);
                fire[4].SetActive(true);
                fire[5].SetActive(false);
                fire[6].SetActive(false);
                break;
            case DamageState.BadlyDamaged:
                fire[0].SetActive(true);
                fire[1].SetActive(true);
                fire[2].SetActive(true);
                fire[3].SetActive(true);
                fire[4].SetActive(true);
                fire[5].SetActive(true);
                fire[6].SetActive(true);
                break;
            case DamageState.Destroyed:
                fire[0].SetActive(false);
                fire[1].SetActive(false);
                fire[2].SetActive(false);
                fire[3].SetActive(false);
                fire[4].SetActive(false);
                fire[5].SetActive(false);
                fire[6].SetActive(false);
                break;
        }
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

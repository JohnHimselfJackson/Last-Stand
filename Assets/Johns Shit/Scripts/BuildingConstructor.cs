using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConstructor : BuildingBasic
{
    public GameObject[] unitPool;
    public GameObject garrisonedUnit;
    public PatrolRoute garrisonPatrolRoute;
    public Vector3 spawnPoint;
    public enum ConstructorState {idle, building};
    public ConstructorState currentState;
    const float trainTime = 15;
    float timetoUnit;

    // Start is called before the first frame update
    void Start()
    {
        garrisonedUnit = null;
        currentState = ConstructorState.idle;
        timetoUnit = trainTime;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGarrisonUnit();
        ConstructUnit();
    }

    void CheckGarrisonUnit()
    {
        if(currentState == ConstructorState.idle && garrisonedUnit == null)
        {
            currentState = ConstructorState.building;
        }
        else if (currentState == ConstructorState.building && garrisonedUnit != null)
        {
            currentState = ConstructorState.idle;
        }
    }

    void ConstructUnit()
    {   if(currentState == ConstructorState.building)
        {
            if (timetoUnit < 0)
            {
                //train unit
                CreateUnit();
            }
            else
            {
                timetoUnit -= Time.deltaTime;
            }

        }
    }
    
    public virtual void CreateUnit()
    {
        garrisonedUnit = Instantiate(unitPool[Random.Range(0, unitPool.Length)], spawnPoint, Quaternion.identity);
        garrisonedUnit.GetComponent<UnitMaster>().CallOnCreation();
        garrisonedUnit.GetComponent<UnitMaster>().SetPatrolRoute(garrisonPatrolRoute);
        garrisonedUnit.GetComponent<UnitMaster>().myConstructor = this;
        timetoUnit = trainTime;
    }
}

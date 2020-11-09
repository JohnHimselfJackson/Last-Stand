using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoster : MonoBehaviour
{
    public bool needInfantry, needVehicle;
    public PatrolRoute[] infantryRoutes;
    public PatrolRoute[] vehicleRoutes;
    public List<GameObject> garrisionedInfantry = new List<GameObject>();
    public List<GameObject> garrisonedVehicles = new List<GameObject>();

    public static EnemyRoster eR;

    private void Awake()
    {
        eR = this;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRoutes();
    }

    void CheckRoutes()
    {
        if (needInfantry)
        {
            foreach (PatrolRoute pR in infantryRoutes)
            {
                if (garrisionedInfantry.Count < 1)
                {
                    break;
                }
                else
                {
                    if(pR.unitsInPatrol < pR.unitPatrolMax)
                    {
                        garrisionedInfantry[0].GetComponent<UnitMaster>().SetPatrolRoute(pR);
                        garrisionedInfantry[0].GetComponent<UnitMaster>().myConstructor.garrisonedUnit = null;
                        garrisionedInfantry.RemoveAt(0);
                    }
                }
            }
        }
    }
}



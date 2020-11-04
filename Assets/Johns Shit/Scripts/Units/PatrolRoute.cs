using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    public Vector3[] points;
    public int unitsInPatrol;
    public int unitPatrolMax;
    public UnitMaster.unitClass patrolType;
    // Start is called before the first frame update
    void Start()
    {
        unitsInPatrol = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        CheckUnits();
    }
    
    private void OnDrawGizmosSelected()
    {
        for(int vv = 0; vv < points.Length; vv++)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(points[vv], points[vv] + Vector3.up * 15);
            if (vv == points.Length - 1)
            {
                Gizmos.DrawLine(points[vv] + Vector3.up * 15, points[0] + Vector3.up * 15);
            }
            else
            {
                Gizmos.DrawLine(points[vv] + Vector3.up * 15, points[vv+1] + Vector3.up * 15);
            }
        }
    }

    void CheckUnits()
    {
        if (unitsInPatrol < unitPatrolMax)
        {
            EnemyRoster.eR.needInfantry = true;
        }
    }

    public void RemoveUnit()
    {
        unitsInPatrol--;
    }
    public void AddUnit()
    {
        unitsInPatrol++;
    }
}

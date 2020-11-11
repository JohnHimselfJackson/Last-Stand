using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDefence : BuildingBasic
{
    public Transform turretBody;
    protected Vector3 myPos;
    protected GameObject activeTarget;
    protected float attackRange;
    protected float fireTime;
    protected float fireTimeCount;
    protected DamagePackage damage;

    const int enemyLayer = 9;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    // Update is called once per frame
    void Update()
    {
        GenericUpdate();
    }
    
    void DetectEnemies()
    {
        if (activeTarget != null)
        {
            Vector3 enemyPos = activeTarget.transform.position;
            if ((enemyPos - myPos).magnitude > attackRange + 8)
            {
                activeTarget = null;
            }
        }
        if (activeTarget == null)
        {
            //checks attack range for enemies
            Collider[] targets = Physics.OverlapCapsule(transform.position + Vector3.down * 3, transform.position + Vector3.up * 3, attackRange+8, 1 << enemyLayer);
            if (targets.Length != 0)
            {
                activeTarget = targets[0].gameObject;
            }
            else
            {
                //print("No target - detect");
            }
        }
    }
    void AimTurret()
    {
        if(activeTarget != null)
        {
            Vector3 tempV3 = activeTarget.transform.position - myPos;
            float temp = Mathf.Atan2(tempV3.x,tempV3.z)*Mathf.Rad2Deg;
            turretBody.rotation = Quaternion.Euler(0,temp,0);
        }
    }

    public virtual void Shoot()
    {
    }
    protected void GenericUpdate()
    {
        DetectEnemies();
        AimTurret();
        if (fireTimeCount > fireTime && activeTarget)
        {
            Shoot();
            fireTimeCount = 0;
        }
        else
        {
            fireTimeCount += Time.deltaTime;
        }
    }
}

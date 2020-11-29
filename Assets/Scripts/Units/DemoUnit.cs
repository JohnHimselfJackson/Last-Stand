using System.Collections;
using System.Collections.Generic;

using UnityEngine.AI;

public class DemoUnit : UnitMaster
{
    public override void CallOnCreation()
    {
        myAgent = GetComponent<NavMeshAgent>();
        nextRallyPoint = 0;
        healthTotal = 40;
        healthCurrent = healthTotal;
        evasion = 2;
        armour = 1;
        myClass = unitClass.light;
        movespeed = 4;
        lineOfSight = 15;
        attackRange = 10;
        attackCooldown = 1;
        damage = new DamagePackage(DamagePackage.damageClass.light, DamagePackage.damageType.standard, 7, attackCooldown *1.2f );

        myAgent.speed = movespeed;
    }
    private void Awake()
    {
        //CallOnCreation();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoUnit : UnitMaster
{
    public override void CallOnCreation()
    {
        healthTotal = 40;
        healthCurrent = healthTotal;
        evasion = 2;
        armour = 1;
        myClass = unitClass.light;
        movespeed = 4;
        lineOfSight = 10;
        attackRange = 1; //8
        attackCooldown = 1;
        damage = new DamagePackage(DamagePackage.damageClass.light, DamagePackage.damageType.standard, 7, attackCooldown *1.2f );
        

        //rallyPos.Add()
    }
}

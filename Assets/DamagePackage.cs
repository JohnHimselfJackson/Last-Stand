using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DamagePackage
{
    public enum damageClass {heavy, Light }
    public damageClass myClass;
    public enum damageType  { standard, AP, direct, trueDamage}
    public damageType myType;
    public float damage;

    public DamagePackage(damageClass tempDC, damageType tempDT, float tempDamage)
    {
        damage = tempDamage;
        myClass = tempDC;
        myType = tempDT;
    }
}

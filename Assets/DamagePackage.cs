using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DamagePackage
{
    public enum damageClass {heavy, light }
    public damageClass myClass;
    public enum damageType  { standard, AP, direct, trueDamage}
    public damageType myType;
    public float damage;
    /// <summary>
    /// damage class, damage type, damage
    /// </summary>
    /// <param name="tempDC"></param>
    /// <param name="tempDT"></param>
    /// <param name="tempDamage"></param>
    public DamagePackage(damageClass tempDC, damageType tempDT, float tempDamage)
    {
        damage = tempDamage;
        myClass = tempDC;
        myType = tempDT;
    }
}

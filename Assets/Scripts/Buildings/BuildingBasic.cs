using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBasic : MonoBehaviour
{
    public float explosionSize;
    public enum buildingType { constructor, defence, command };
    public buildingType myType;
    public enum unitClass { heavy, light };
    public unitClass myClass = unitClass.heavy;
    public int healthCurrent;
    public int healthMax;

    public enum DamageState { Healthy, Damaged, BadlyDamaged, Destroyed };
    public DamageState damageState;

    private int healthy = 100;
    private int damaged = 75;
    private int badlyDamaged = 25;
    private int destroyed = 0;

    protected int armour;
    protected int evasion;
    

    // Start is called before the first frame update
    void Start()
    {
        armour = 1;
        evasion = 0;
        healthMax = 100;
        healthCurrent = healthMax;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageResolution(DamagePackage incomingDamage)
    {
        #region VariableCalculations
        int damageTemp = incomingDamage.damage;
        int finalDamage = 0;
        if(incomingDamage.myClass == DamagePackage.damageClass.heavy)
        {
            damageTemp *= 2;
        }

        #endregion
        //divides incoming damage up according to type
        switch (incomingDamage.myType)
        {
            #region Standard Damage
            case DamagePackage.damageType.standard:
                finalDamage = damageTemp;
                finalDamage -= (armour + evasion);
                if (finalDamage < 0)
                {
                    finalDamage = 0;
                }
                break;
            #endregion
            #region Direct Damage
            case DamagePackage.damageType.direct:
                finalDamage = damageTemp;
                finalDamage -= armour;
                if (finalDamage < 0)
                {
                    finalDamage = 0;
                }
                break;
            #endregion
            #region AP Damage
            case DamagePackage.damageType.AP:
                finalDamage = damageTemp;
                finalDamage -= evasion;
                if (finalDamage < 0)
                {
                    finalDamage = 0;
                }
                break;
            #endregion
            #region True Damage
            case DamagePackage.damageType.trueDamage:
                finalDamage = incomingDamage.damage;
                if (finalDamage < 0)
                {
                    finalDamage = 0;
                }
                break;
                #endregion
        }
        healthCurrent -= finalDamage;

        HealthCheck();
    }

    private void HealthCheck()
    {
        if (healthCurrent >= healthy || healthCurrent > damaged)
        {
            damageState = DamageState.Healthy;
            return;
        }

        if (healthCurrent <= damaged && healthCurrent > badlyDamaged)
        {
            damageState = DamageState.Damaged;
            return;
        }

        if (healthCurrent <= badlyDamaged && healthCurrent > destroyed)
        {
            damageState = DamageState.BadlyDamaged;
            return;
        }

        if (healthCurrent <= destroyed)
        {
            damageState = DamageState.Destroyed;
            BuildingDestroyed();
            return;
        }
    }

    public virtual void BuildingDestroyed()
    {
        ExplosionPool.explosionPool.GetObject().GetComponent<ExplosionLogic>().BeginExplosion(transform.position , explosionSize);
        Destroy(gameObject);
    }
}

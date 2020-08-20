using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMaster : MonoBehaviour
{
    #region Base StatBLock
    protected float healthTotal;
    protected float healthCurrent;
    protected int evasion;
    protected int armour;
    public enum unitClass {heavy, light};
    protected unitClass myClass;
    protected float movespeed;
    protected float lineOfSight;
    protected float attackRange;
    protected DamagePackage damage;
    protected float attackCooldown;
    #endregion

    #region Unit Consts
    const int enemyLayer = 9;
    const int coverLayer = 10;
    #endregion

    #region nav variables
    //TODO replaced with navmesh locations    
    protected Vector3 myPos;
    protected Vector3 activeRally;
    protected List<Vector3> rallyPos; // will be set on unit creation
    protected Vector3 activeFlare;    // will be set when a flare is used
    #endregion

    #region Shooting Variables    
    protected GameObject activeTarget;
    protected bool attacking;
    protected float attackTime;
    #endregion

    #region Combat Variables
    protected bool underFire;
    public bool inCover;
    protected bool MovToCover;
    #endregion
    
    void Start()
    {
        InvokeRepeating("ActionLoop", 0, 0.25f);
    }
    
    void Update()
    {
        myPos = transform.position;
        UpdateAttack();
    }

    #region Unit Functions
    public virtual void CallOnCreation()
    {

    }




    //runs in update and handles the start of the attack
    void UpdateAttack()
    {
        //checks if the unit is set to attacking and there is a active target to attack
        if (attacking && activeTarget != null)
        {
            #region Target Confirmation - After this active target will either be null or a GO for if there isnt or is an enemy respectively
            //gets the position of the enemy
            Vector3 enemyPos = activeTarget.transform.position;
            //checks if the current active target is within range of the current unit
            if ((enemyPos - myPos).magnitude > attackRange)
            {
                //if not in range sets the active target to null
                activeTarget = null;

                //checks attack range for enemies incase there is a new enemy in range
                Collider[] targets = Physics.OverlapCapsule(transform.position + Vector3.down * 3, transform.position + Vector3.up * 3, attackRange, 1 << enemyLayer);
                if (targets.Length != 0)
                {
                    activeTarget = targets[0].gameObject;
                }
                else
                {
                    print("no targets in range");
                }
            }
            #endregion
            #region Actual Attack - the code for the attack
            //runs for unit to attack
            if (activeTarget)
            {
                //for attack delay and handling attack rate

                //checks if time for attack
                if (attackTime < attackCooldown)
                {
                    Invoke("Attack", 0f);
                }
                //if not time yet alters attacktime float 
                else
                {
                    attackTime += Time.deltaTime;
                }
            }
            #endregion
        }
        // checks if meant to be attacking but has no target
        else if (activeTarget == null && attacking)
        {
            //the unit is being told to attack despite no active target. this will result is calling action loop to re-evaluate the situation
            ActionLoop();
        }
        else
        {
            //default part if not attacking and no active target
        }
    }

    //function for when unit commits to attack
    void Attack()
    {
        //ETS attack code here
    }

    //core action loop for all non buildings
    void ActionLoop()
    {
        //detrermines target
        DetectEnemies();
        // if a light unit is able to in combat (has a target and underfire) and it is not yet in cover it will check if there is any nearby cover
        if (activeTarget != null &&
            underFire && 
            !inCover &&
            myClass == unitClass.light &&
            !MovToCover)
        {
            DetectCover();
        }
        
        // if needs to move to cover
        if (MovToCover)
        {
            if (inCover || !activeTarget || !underFire)
            {
                MovToCover = false;
            }
        }
        //if attacking and not getting shot
        else if(activeTarget)
        {
            //TODO: stop movement of unit
            //sets attacking bool true so that in update the full UpdateAttack(); will run
            attacking = true;
            MovToCover = false;
        }
        //if not attacking
        else
        {
            attacking = false;
            MovToCover = false;
            UnitMove();
        }
    }

    //code for all unit movement other than moving to cover
    void UnitMove()
    {
        //standard move logic        
            if (activeRally == null)
            {
                //if a flare is active
                if (activeFlare != null)
                {
                    //set path to active flare
                    activeRally = activeFlare;
                }
                //if still has rally location
                else if (rallyPos.Count != 0)
                {
                    //sets first index in the list to the active rally and then removes it from rally point list
                    activeRally = rallyPos[0];
                    rallyPos.RemoveAt(0);
                }
                // if no other rally to set auto targets the main buildings
                else
                {
                    // if first base alive target that
                    if (EnemySingleton.main.firstBaseAlive)
                    {
                        activeRally = EnemySingleton.main.firstLoc;
                    }
                    // if second base alive target that
                    else if (EnemySingleton.main.secondBaseAlive)
                    {
                        activeRally = EnemySingleton.main.secondLoc;
                    }
                    // if third base alive target that. This is the last call for all units as there is no need to path to something after the third is destroyed.
                    else
                    {
                        activeRally = EnemySingleton.main.thirdLoc;
                    }
                }
            }
            else
            {
                //if a flare is active
                if (activeFlare != null)
                {
                    //adds current location to start of list so when flare ends will continue to previous point
                    rallyPos.Insert(0, activeRally);

                    //set path to active flare
                    activeRally = activeFlare;
                }

            }
    }

    //code to dectect if there are any attack enemies in range and set activeTarget accordingly
    void DetectEnemies()
    {
        if (activeTarget != null)
        {
            Vector3 enemyPos = activeTarget.transform.position;
            if ((enemyPos - myPos).magnitude > attackRange)
            {
                activeTarget = null;
            }
        }
        if (activeTarget == null)
        {
            //checks attack range for enemies
            Collider[] targets = Physics.OverlapCapsule(transform.position + Vector3.down * 3, transform.position + Vector3.up * 3, attackRange, 1 << enemyLayer);
            if (targets.Length != 0)
            {
                activeTarget = targets[0].gameObject;
            }
            else
            {
                print("no targets in range");
            }
        }
    }

    //check if any cover in range
    void DetectCover()
    {
        //TODO: finish cover finding code when cover is implemented

        GameObject closestCover = null;
        //finds all cover in seconds of movement range
        Collider[] cover = Physics.OverlapCapsule(transform.position + Vector3.down * 3, transform.position + Vector3.up * 3, 2 * movespeed, 1 << coverLayer);
        //cycles through all found cover to find the closest
        for(int cc = 0; cc < cover.Length; cc++)
        {
            //checks if already has a cover
            if (closestCover != null)
            {
                // is it closer than the previous
                if ((closestCover.transform.position - myPos).magnitude > (cover[cc].transform.position - myPos).magnitude)
                {
                    /*
                     // checks if the cover can be reached
                     if(can navigate to cover)
                     {                        
                        closestCover = cover[cc].gameObject;
                     }                 
                    */
                }
            }
            //runs if no previously established cover
            else
            {
                /*
                 // checks if the cover can be reached
                 if(can navigate to cover)
                 {
                    closestCover = cover[cc].gameObject;
                 }                 
                */
            }
        }
        // if there is a cover sets move to tue and to move to that cover
        if(closestCover != null)
        {
                //TODO: set to move to cover
                MovToCover = true;
        }




        if (cover.Length != 0)
        {
            activeTarget = cover[0].gameObject;
        }
        else
        {
            print("no targets in range");
        }
    }

    /// <summary>
    /// call to damage THIS unit
    /// </summary>
    /// <param name="dp"></param>
    /// <param name="UFDelay"></param>
    public void DamageUnit(DamagePackage dp)
    {
        underFire = true;
        Invoke("NUF", dp.UFD);
        DamageResolution(dp);
    }

    //invoked to set underFire bool to false
    void NUF()
    {
        underFire = false;
    }
    #endregion

    public void DamageResolution(DamagePackage incomingDamage)
    {
        #region VariableCalculations
        int finalDamage = 0;
        int tempEvasion = evasion;
        switch (incomingDamage.myClass)
        {
            case DamagePackage.damageClass.heavy:
                if(myClass == unitClass.light)
                {
                    tempEvasion *= 2;
                }
                break;
            case DamagePackage.damageClass.light:
                if (myClass == unitClass.heavy)
                {
                    tempEvasion = (int)(tempEvasion/2);
                }
                break;
        }

        #endregion
        //divides incoming damage up according to type
        switch (incomingDamage.myType)
        {
            #region Standard Damage
            case DamagePackage.damageType.standard:
                finalDamage= incomingDamage.damage;
                finalDamage -= (armour + tempEvasion);
                if(finalDamage < 0)
                {
                    finalDamage = 0;
                }
                break;
            #endregion
            #region Direct Damage
            case DamagePackage.damageType.direct:
                finalDamage = incomingDamage.damage;
                finalDamage -= armour;
                if (finalDamage < 0)
                {
                    finalDamage = 0;
                }
                break;
            #endregion
            #region AP Damage
            case DamagePackage.damageType.AP:
                finalDamage = incomingDamage.damage;
                finalDamage -=tempEvasion;
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
        //checks if the player is dead
        if (healthCurrent < 1)
        {
            UnitDead();
        }
    }

    void UnitDead()
    {
        Destroy(gameObject);
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    public Vector3 activeRally;
    protected int nextRallyPoint = 0;
    private PatrolRoute pRoute;
    public BuildingConstructor myConstructor;
    protected NavMeshAgent myAgent;
    protected float chaseTime;
    protected bool chasing;
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.DrawSphere(activeRally, 1);
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
                    print(activeTarget.name);
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
                    attackTime = attackCooldown;
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
        GameObject projectile = EnemyProjectilePool.enemyPool.GetObject();
        projectile.GetComponent<EnemyBulletLogic>().StartBullet(transform.position, activeTarget.transform.position, attackRange, damage);
    }

    //core action loop for all non buildings
    void ActionLoop()
    {
        //detrermines target
        DetectEnemies();

        if (activeTarget)
        {
            //TODO: stop movement of unit
            //sets attacking bool true so that in update the full UpdateAttack(); will run
            myAgent.isStopped = true;
            attacking = true;
            chasing = true;
        }
        else if (chasing && chaseTime < 5)
        {
            myAgent.isStopped = false;
            myAgent.SetDestination(EnemySingleton.main.playerLocation.position);
            chaseTime += Time.deltaTime;
        }
        else if (chasing && chaseTime >= 5)
        {
            chasing = false;
            chaseTime = 0;
            nextRallyPoint--;
            if (nextRallyPoint < 0)
            {
                nextRallyPoint = pRoute.points.Length - 1;
            }
            myAgent.SetDestination(pRoute.points[nextRallyPoint]);
            nextRallyPoint++;
        }
        //if not attacking
        else
        {
            chasing = false;
            attacking = false;
            myAgent.isStopped = false;
            UnitMove();
        }
    }

    //code for all unit movement other than moving to cover
    void UnitMove()
    {
        //standard move logic        
        if (myAgent.hasPath == false)
        {
            Vector3 nextRally = pRoute.points[nextRallyPoint];
            activeRally = nextRally;
            myAgent.SetDestination(nextRally);
            nextRallyPoint++;
            if (nextRallyPoint > (pRoute.points.Length-1))
            {
                nextRallyPoint = 0;
            }
        }
        else
        {
            //progressing to next rally
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
                print(activeTarget.name);
            }
            else
            {
                //print("No target - detect");
            }
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
        pRoute.RemoveUnit();
        if(myConstructor.garrisonedUnit == gameObject)
        {
            myConstructor.garrisonedUnit = null;
        }
        Destroy(gameObject);
    }    

    public void SetPatrolRoute(PatrolRoute newRoute)
    {
        if(pRoute != null)
        {
            pRoute.RemoveUnit();
        }
        pRoute = newRoute;
        pRoute.AddUnit();
    }
    
}

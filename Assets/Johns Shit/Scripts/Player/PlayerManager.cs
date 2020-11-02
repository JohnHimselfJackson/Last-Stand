using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VulpineAlice.TooltipUI;

public class PlayerManager : MonoBehaviour
{
    public Stats health, armour;

    private float healthTotal;
    private float healthCurrent;

    private float evasionChance;
    private float grazeChance;
    private int evasionCountTotal;
    private int evasionCountCurrent;

    private int armourDecrease;
    private int deflectionValue;
    private float armourTotal;
    private float armourCurrent;




    public static PlayerManager pM;
    public PlayerController pC;

    private void Awake()
    {
        pM = this;
        pC = GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayer()
    {
        //gives player controller the staat block and loads values into it
        pC.SetOnLoad(PlayerData.playerStats);

        //retrieving the needed stat arrays to assign values in player controller
        float[] baseStats = PlayerData.playerStats.ReturnValues("base", "final");
        float[] defenceStats = PlayerData.playerStats.ReturnValues("defence", "final");

        #region assigning variables for player manager
        healthTotal = baseStats[0];
        healthCurrent = healthTotal;

        evasionChance = defenceStats[0];
        grazeChance = defenceStats[1];
        evasionCountTotal = (int)defenceStats[2];
        evasionCountCurrent = evasionCountTotal;


        armourDecrease = (int)defenceStats[3];
        deflectionValue = (int)defenceStats[4];
        armourTotal = defenceStats[5];
        armourCurrent = armourTotal;
        #endregion

        //player UI canvas
        health.statMax = healthTotal;
        armour.statMax = armourTotal;
        armour.StatCalc(armourCurrent);
        health.StatCalc(healthCurrent);

        pC.UnlockPlayer();


    }

    public bool PlayerDamageResolution(DamagePackage incomingDamage)
    {
        #region VariableCalculations
        //variable used for evasion caluclations
        int hitNo;

        bool projectileResolved = false;
        //creates temporary variables so they can be modified in caluclation
        float tempEvasionChance = evasionChance;
        float tempGrazeChance = grazeChance;
        //checks to see if incoming attack is a heavy attack for heavy vs light bonus
        if(incomingDamage.myClass == DamagePackage.damageClass.heavy)
        {
            //doubles evasion and graze chance as lvh bonus
            tempEvasionChance *= 2;
            tempGrazeChance *= 2;
        }
        #endregion

        if (pC.diving)
        {
            projectileResolved = false;
        }
        else
        {
            //divides incoming damage up according to type
            switch (incomingDamage.myType)
            {
                #region Standard Damage
                case DamagePackage.damageType.standard:
                    int finalDamage;
                    //rng number for if attack hits
                    hitNo = Random.Range(0, 101);
                    // if number is greater than the graze chance it is a full hit
                    if (hitNo > tempGrazeChance)
                    {
                        finalDamage = ArmourCalc(incomingDamage.damage);
                        //projectile has hit the player
                        projectileResolved = true;
                    }
                    //this happens it hit number is less than the graze but more than the full evade. if this happens the damage is halved
                    else if (hitNo > tempEvasionChance)
                    {
                        finalDamage = ArmourCalc((int)(incomingDamage.damage / 2));
                        //rpojectile has hit the player
                        projectileResolved = true;
                    }
                    //if the hit number is less than the evasion chance number its a complete dodge
                    else
                    {
                        finalDamage = 0;
                        //rpojectile has missed the player
                        projectileResolved = false;
                        //dodged
                    }

                    //calucation after final damage found 
                    healthCurrent -= finalDamage;
                    if (healthCurrent < 0)
                    {
                        healthCurrent = 0;
                    }
                    break;
                #endregion
                #region Direct Damage
                case DamagePackage.damageType.direct:
                    //subtracts the damage done after armour form the players current health
                    healthCurrent -= ArmourCalc(incomingDamage.damage);
                    if (healthCurrent < 0)
                    {
                        healthCurrent = 0;
                    }
                    //rpojectile has hit the player
                    projectileResolved = true;
                    break;
                #endregion
                #region AP Damage
                case DamagePackage.damageType.AP:
                    //rng number for if attack hits
                    hitNo = Random.Range(0, 100);

                    // if number is greater than the graze chance it is a full hit
                    if (hitNo > tempGrazeChance)
                    {
                        finalDamage = incomingDamage.damage;
                        //rpojectile has hit the player
                        projectileResolved = true;
                    }
                    //this happens it hit number is less than the graze but more than the full evade. if this happens the damage is halved
                    else if (hitNo > tempEvasionChance)
                    {
                        finalDamage = (int)(incomingDamage.damage / 2);
                        //rpojectile has hit the player
                        projectileResolved = true;
                    }
                    //if the hit number is less than the evasion chance number its a complete dodge
                    else
                    {
                        finalDamage = 0;
                        //rpojectile has missed the player
                        projectileResolved = false;
                        //dodged
                    }
                    //calucation after final damage found 
                    healthCurrent -= finalDamage;
                    if (healthCurrent < 0)
                    {
                        healthCurrent = 0;
                    }

                    break;
                #endregion
                #region True Damage
                case DamagePackage.damageType.trueDamage:

                    healthCurrent -= incomingDamage.damage;
                    if (healthCurrent < 0)
                    {
                        healthCurrent = 0;
                    }
                    //pojectile has hit the player
                    projectileResolved = true;
                    break;
                    #endregion
            }
            //updates UI
            armour.StatCalc(armourCurrent);
            health.StatCalc(healthCurrent);

            //checks if the player is dead
            if (healthCurrent < 1)
            {
                PlayerDead();
            }
        }

        //returns projectile resolved to see if the projectile is done or if it continues past the player (miss)
        return projectileResolved;
    }

    //used within the damage resolution function to help calculate the damage dealt to player based on their armour
    int ArmourCalc(int damage)
    {
        //saves initial damage for later reference
        int startingDamage =damage;
        //checks if damage is less than defelction value and returns 0 if so
        if(damage <= deflectionValue)
        {
            return 0;
        }
        //calculates the damage that will be dealt after armour
        int temp = damage - armourDecrease;
        //subtracts the damage dealt from the armour
        armourCurrent -= startingDamage - temp;
        //if the remaining armour is less than 0 make it = o
        if (armourCurrent < 0)
        {
            armourCurrent = 0;
        }
        //returns final damage
        return temp;
    }

    void PlayerDead()
    {

    }

}

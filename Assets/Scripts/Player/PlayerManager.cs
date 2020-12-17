using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VulpineAlice.TooltipUI;

public class PlayerManager : MonoBehaviour
{
    #region Health and Armour

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
    #endregion

    #region passives
    bool gotBioArmour, gotMedSuite;
    float armourTick, healthTick;
    float timeSinceDamage;

    #endregion

    #region Active Abilities    
    public ActiveAbility eAbility, qAbility;
    public Image eAbilityImage, qAbilityImage;
    public GameObject eHolder, qHolder;
    #endregion 

    public static PlayerManager pM;
    public PlayerController pC;
    float fpsCheck;
    float evasionTime;

    public Image armourBar, healthBar, dodgeBar;

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
        if(timeSinceDamage < 4)
        {
            timeSinceDamage += Time.deltaTime;
        }
        if(gotMedSuite) MedSuiteFunction();
        if(gotBioArmour) BioArmourFunction();
        AbilityCooldowns();

        if (Time.time> fpsCheck)
        {
            fpsCheck++;
            
            //print(1/Time.deltaTime);
        }


        if(evasionCountCurrent < evasionCountTotal && evasionTime > 1.5)
        {
            evasionCountCurrent++;
            dodgeBar.fillAmount = (float)evasionCountCurrent / (float)evasionCountTotal;
            evasionTime = 0;
        }
        else
        {
            evasionTime += Time.deltaTime;
        }

    }

    public void LoadPlayer()
    {
        //gives player controller the staat block and loads values into it
        pC.SetOnLoad(PlayerData.playerStats);
        //
        //

        //add part here where checks stat block for abilities unlocked
        gotBioArmour = PlayerData.playerStats.gotBioArmour;
        gotMedSuite = PlayerData.playerStats.gotMedSuite;
        pC.gotGL = PlayerData.playerStats.gotGrenade;
        pC.gotSL = PlayerData.playerStats.gotLaser;
        pC.gotSL = true;
        switch (PlayerData.playerStats.qAbility)
        {
            case 0: //impulse thrusters
                qAbility = GetComponent<ImpulseThrusters>();
                break;
            case 1: //shield
                qAbility = GetComponent<Shield>();
                break;
            case 2: //juggernaught
                qAbility = GetComponent<JuggernaughtMode>();
                break;
            case 3: //overcharge
                qAbility = GetComponent<SuitOvercharge>();
                break;
            default:
                qAbility = null;
                break;
        }
        switch (PlayerData.playerStats.eAbility)
        {
            case 0: //impulse thrusters
                eAbility = GetComponent<ImpulseThrusters>();
                break;
            case 1: //shield
                eAbility = GetComponent<Shield>();
                break;
            case 2: //juggernaught
                eAbility = GetComponent<JuggernaughtMode>();
                break;
            case 3: //overcharge
                eAbility = GetComponent<SuitOvercharge>();
                break;
            default:
                eAbility = null;
                break;
        }
        //
        //
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
                    if (hitNo > tempGrazeChance || evasionCountCurrent < 1)
                    {
                        finalDamage = ArmourCalc(incomingDamage.damage);
                        //projectile has hit the player
                        projectileResolved = true;
                    }
                    //this happens it hit number is less than the graze but more than the full evade. if this happens the damage is halved
                    else if (hitNo > tempEvasionChance)
                    {
                        finalDamage = ArmourCalc((int)(incomingDamage.damage / 2));
                        evasionCountCurrent--;
                        evasionTime = 0;
                        print("dodged");
                        //rpojectile has hit the player
                        projectileResolved = true;
                    }
                    //if the hit number is less than the evasion chance number its a complete dodge
                    else
                    {
                        finalDamage = 0;
                        //rpojectile has missed the player
                        projectileResolved = true;
                        evasionCountCurrent--;
                        evasionTime = 0;

                        //dodged
                    }

                    //calucation after final damage found 
                    healthCurrent -= finalDamage;
                    timeSinceDamage = 0;
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
                    timeSinceDamage = 0;
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
                    if (hitNo > tempGrazeChance || evasionCountCurrent < 1)
                    {
                        finalDamage = incomingDamage.damage;
                        //rpojectile has hit the player
                        projectileResolved = true;
                    }
                    //this happens it hit number is less than the graze but more than the full evade. if this happens the damage is halved
                    else if (hitNo > tempEvasionChance)
                    {
                        finalDamage = (int)(incomingDamage.damage / 2);
                        evasionCountCurrent--;
                        evasionTime = 0;
                        print("dodged");
                        //rpojectile has hit the player
                        projectileResolved = true;
                    }
                    //if the hit number is less than the evasion chance number its a complete dodge
                    else
                    {
                        finalDamage = 0;
                        evasionCountCurrent--;
                        evasionTime = 0;
                        print("dodged");
                        //rpojectile has missed the player
                        projectileResolved = true;
                        //dodged
                    }
                    //calucation after final damage found 
                    healthCurrent -= finalDamage;
                    timeSinceDamage = 0;
                    if (healthCurrent < 0)
                    {
                        healthCurrent = 0;
                    }

                    break;
                #endregion
                #region True Damage
                case DamagePackage.damageType.trueDamage:

                    healthCurrent -= incomingDamage.damage;
                    timeSinceDamage = 0;
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
            healthBar.fillAmount = healthCurrent / healthTotal;
            armourBar.fillAmount = armourCurrent / armourTotal;
            dodgeBar.fillAmount = (float)evasionCountCurrent/ (float)evasionCountTotal;

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
        pC.myAnim.SetBool("dead", true);
        pC.LockPlayer();
        print("get gud fuckboi");
    }

    #region abilities
    void BioArmourFunction()
    {
        //print("current armour" + armourCurrent + " armour tick:" + armourTick + " time since damage:" + timeSinceDamage);
        if (armourCurrent < armourTotal && timeSinceDamage >= 4 && armourTick > 2)
        {
            armourCurrent += 1;
            armourTick = 0;
            if(armourCurrent > armourTotal)
            {
                armourCurrent = armourTotal;
            }
            armourBar.fillAmount = armourCurrent / armourTotal;
        }
        else if(armourCurrent < armourTotal && armourTick < 2)
        {
            armourTick +=Time.deltaTime;
        }
    }
    void MedSuiteFunction()
    {
        if (healthCurrent < healthTotal && timeSinceDamage >= 4 && healthTick > 3)
        {
            healthCurrent += 2;
            healthTick = 0;
            if (healthCurrent > healthTotal)
            {
                healthCurrent = healthTotal;
            }
            healthBar.fillAmount = healthCurrent / healthTotal;
        }
        else if(healthCurrent < healthTotal && healthTick > 3)
        {
            healthCurrent += 1;
            healthTick = 0;
            if (healthCurrent > healthTotal)
            {
                healthCurrent = healthTotal;
            }
            healthBar.fillAmount = healthCurrent / healthTotal;

        }
        else if (healthCurrent < healthTotal && healthTick < 3)
        {
            healthTick += Time.deltaTime;
        }

    }
    public void JuggernaughtChange(int armourDecreaseIncrease, float armourIncrease, int deflectionValueIncrease)
    {
        armourDecrease += armourDecreaseIncrease;
        armourCurrent += armourIncrease;
        armourTotal += armourIncrease;
        deflectionValue += deflectionValueIncrease;
    }
    public void JuggernaughtOver(int armourDecreaseIncrease, float armourIncrease, int deflectionValueIncrease)
    {
        armourDecrease -= armourDecreaseIncrease;
        deflectionValue -= deflectionValueIncrease;

        armourCurrent -= armourIncrease;
        armourTotal -= armourIncrease;
        if (armourCurrent < 0) armourCurrent = 0;
    }
    public void OverchargeChange(int dodgeCountIncrease, float dodgeChangeIncrease)
    {
        evasionChance += dodgeChangeIncrease;
        grazeChance += dodgeChangeIncrease;
        evasionCountCurrent += dodgeCountIncrease;
        evasionCountTotal += dodgeCountIncrease;
    }
    public void OverchargeOver(int dodgeCountIncrease, float dodgeChangeIncrease)
    {
        evasionChance -= dodgeChangeIncrease;
        grazeChance -= dodgeChangeIncrease;
        evasionCountCurrent -= dodgeCountIncrease;
        evasionCountTotal -= dodgeCountIncrease;
        if (evasionCountCurrent < 0) evasionCountCurrent = 0;
    }
    #endregion




    void AbilityCooldowns()
    {
        if (eAbility != null)
        {
            if(eAbility.cooldownCount > 0)
            {
                eAbilityImage.fillAmount = (eAbility.cooldown- eAbility.cooldownCount) / eAbility.cooldown;
            }
            else
            {
                eAbilityImage.fillAmount = 1;
            }
        }
        else if(eHolder.activeInHierarchy == true)
        {
            eHolder.SetActive(false);
        }

        if (qAbility != null)
        {
            if (qAbility.cooldownCount > 0)
            {
                qAbilityImage.fillAmount = (qAbility.cooldown - qAbility.cooldownCount) / qAbility.cooldown;
            }
            else
            {
                qAbilityImage.fillAmount = 1;
            }
        }
        else if (qHolder.activeInHierarchy == true)
        {
            qHolder.SetActive(false);
        }
    }
}

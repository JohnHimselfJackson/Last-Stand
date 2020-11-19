using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static StatBlock playerStats = new StatBlock();
    // Start is called before the first frame update
    void Awake()
    {
        playerStats.NewStatBlock();
    }
    
}



public class StatBlock
{
    //melee, rifle, sniper, durability, transcendal, basic
    #region stats
    static readonly float[] baseMeleeValues = { 35, 0, 4 , 0.3f, 0.9f, 3 }; // damage, attack class, damage type, attack speed, attack cooldown, consectutive attacks
    float[] modMeleeValues = new float[6];
    static readonly float[] baseRifleValues = {8, 0, 1, 30, 1.6f, 0.2f, 20, 30, 0}; // damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
    float[] modRifleValues = new float[9];
    static readonly float[] baseSniperValues = { 20, 0, 4, 6, 2.5f, 1.2f, 35, 0, 0 }; // damage, attack class, damage type, ammo, reload, firerate, range, Spread, penertration
    float[] modSniperValues = new float[9];
    static readonly float[] baseStatValues = {100, 3, 40, 10}; // HP, move speed, veiw range, enviromental protection
    float[] modStatValues = new float[4];
    static readonly float[] baseDefenceValues = {10, 15, 8, 4, 2, 70}; //evasion chance, graze chance, evasion number, armor decrease, negation value, armor hp
    float[] modDefenceValues = new float[6];
    public int qAbility;
    public int eAbility;
    public bool gotBioArmour;
    public bool gotMedSuite;
    public bool gotGrenade;
    public bool gotLaser;
    #endregion


    #region Value Changes
    /// <summary>
    /// input array [damage, attack speed, attack cooldown, consectutive attacks]
    /// </summary>
    public void ChangeMeleeValues(float[] array)
    {
        if(array.Length == 6)
        {
            for (int vv = 0; vv < baseMeleeValues.Length; vv++)
            {
                switch (vv)
                {
                    case 1:
                        modMeleeValues[vv] = array[vv];
                        if (modMeleeValues[vv] != 0 || modMeleeValues[vv]  != 1)
                        {
                            modMeleeValues[vv] = 0;
                        }
                        break;
                    case 2:
                        modMeleeValues[vv] = array[vv];
                        if (modMeleeValues[vv] != 4)
                        {
                            modMeleeValues[vv] = 0;
                        }
                        break;
                    case 0:
                    case 3:
                    case 4:
                    case 5:
                        modMeleeValues[vv] += array[vv];
                        break;
                }
            }
        }
        else
        {
            Debug.Log("pleasse enter a correct size array for melee modification ** " + array.Length + "incorrect");
        }
        if (StatsDisplayController.main != null) StatsDisplayController.main.AlterStatsDisplay(this);
    } // UTD
    /// <summary>
    /// input array [damage, crit chance, ammo, reload, firerate, range, accuracy, penertration]
    /// </summary>
    public void ChangeRifleValues(float[] array) 
    {
        if (array.Length == 9)
        {
            for (int vv = 0; vv < baseRifleValues.Length; vv++)
            {
                switch (vv)
                {
                    case 1:
                        modRifleValues[vv] = array[vv];
                        if (modRifleValues[vv] != 0 || modRifleValues[vv] != 1)
                        {
                            modRifleValues[vv] = 0;
                        }
                        break;
                    case 2:
                        modRifleValues[vv] = array[vv];
                        if (modRifleValues[vv] != 0 || modRifleValues[vv] != 1 || modRifleValues[vv] != 2 || modRifleValues[vv] != 3 || modRifleValues[vv] !=  4)
                        {
                            modRifleValues[vv] = 0;
                        }
                        break;
                    case 0:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        modRifleValues[vv] += array[vv];
                        break;
                }
            }
        }
        else
        {
            Debug.Log("pleasse enter a correct size array for rifle modification **" + array.Length + " incorrect");
        }
        if (StatsDisplayController.main != null) StatsDisplayController.main.AlterStatsDisplay(this);
    }// UTD
    public void ChangeSniperValues(float[] array)
    {
        if (array.Length == 9)
        {
            float[] finalReturn = new float[9];
            for (int vv = 0; vv < baseSniperValues.Length; vv++)
            {
                switch (vv)
                {
                    case 1:
                        modSniperValues[vv] = array[vv];
                        if (modSniperValues[vv] != 0 || modSniperValues[vv] != 1)
                        {
                            modSniperValues[vv] = 0;
                        }
                        break;
                    case 2:
                        modSniperValues[vv] = array[vv];
                        if ( modSniperValues[vv] != 4)
                        {
                            modSniperValues[vv] = 4;
                        }
                        break;
                    case 0:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        modSniperValues[vv] += array[vv];
                        break;
                }
            }
        }
        else
        {
            Debug.Log("pleasse enter a correct size array for Sniper modification **" + array.Length + " incorrect");
        }
        if (StatsDisplayController.main != null) StatsDisplayController.main.AlterStatsDisplay(this);
    }// UTD
    public void ChangeStatValues(float[] array)
    {
        if (array.Length == 4)
        {
            float[] finalReturn = new float[8];
            for (int vv = 0; vv < baseStatValues.Length; vv++)
            {
                switch (vv)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        modStatValues[vv] += array[vv];
                        break;
                }
            }
        }
        else
        {
            Debug.Log("please enter a correct size array for Stat modification **" + array.Length + " incorrect");
        }
        if (StatsDisplayController.main != null) StatsDisplayController.main.AlterStatsDisplay(this);
    } //UTD
    public void ChangeDefenceValues(float[] array)
    {
        if (array.Length == 6)
        {
            float[] finalReturn = new float[8];
            for (int vv = 0; vv < baseDefenceValues.Length; vv++)
            {
                switch (vv)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        modDefenceValues[vv] += array[vv];
                        break;
                }
            }
        }
        else
        {
            Debug.Log("pleasse enter a correct size array for Defence modification **" + array.Length + " incorrect");
        }
        if (StatsDisplayController.main != null) StatsDisplayController.main.AlterStatsDisplay(this);
    }  // UTD
    
    #endregion

    public void NewStatBlock()
    {
        modMeleeValues = new float[] { 0, 0, 0, 0 ,0 ,0 };
        modRifleValues = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        modSniperValues = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        modStatValues = new float[] { 0, 0, 0, 0};
        modDefenceValues = new float[] { 0, 0, 0, 0, 0, 0};
        
        if (StatsDisplayController.main != null) StatsDisplayController.main.AlterStatsDisplay(this);    
    }
    public float[] ReturnValues(string type, string stage)
    {
        switch (type)
        {
            case "melee":
                switch (stage)
                {
                    case "base":
                        return baseMeleeValues;
                    case "mod":
                        return modMeleeValues;
                    case "final":
                        float[] finalReturn = new float[6];
                        for (int vv = 0; vv < baseMeleeValues.Length; vv++)
                        {
                            finalReturn[vv] = baseMeleeValues[vv] + modMeleeValues[vv];
                        }
                        return finalReturn;
                }
                break;
            case "rifle":
                switch (stage)
                {
                    case "base":
                        return baseRifleValues;
                    case "mod":
                        return modRifleValues;
                    case "final":
                        float[] finalReturn = new float[9];
                        for (int vv = 0; vv < baseRifleValues.Length; vv++)
                        {
                            finalReturn[vv] = baseRifleValues[vv] + modRifleValues[vv];
                        }
                        return finalReturn;
                }
                break;
            case "sniper":
                switch (stage)
                {
                    case "base":
                        return baseSniperValues;
                    case "mod":
                        return modSniperValues;
                    case "final":
                        float[] finalReturn = new float[9];
                        for (int vv = 0; vv < baseSniperValues.Length; vv++)
                        {
                            finalReturn[vv] = baseSniperValues[vv] + modSniperValues[vv];
                        }
                        return finalReturn;
                }
                break;
            case "base":
                switch (stage)
                {
                    case "base":
                        return baseStatValues;
                    case "mod":
                        return modStatValues;
                    case "final":
                        float[] finalReturn = new float[4];
                        for (int vv = 0; vv < baseStatValues.Length; vv++)
                        {
                            finalReturn[vv] = baseStatValues[vv] + modStatValues[vv];
                        }
                        return finalReturn;
                }
                break;
            case "defence":
                switch (stage)
                {
                    case "base":
                        return baseDefenceValues;
                    case "mod":
                        return modDefenceValues;
                    case "final":
                        float[] finalReturn = new float[6];
                        for (int vv = 0; vv < baseDefenceValues.Length; vv++)
                        {
                            finalReturn[vv] = baseDefenceValues[vv] + modDefenceValues[vv];
                        }
                        return finalReturn;
                }
                break;

        }
        return null;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsDisplayController : MonoBehaviour
{
    public TMP_Text weaponsTB;
    public TMP_Text ArmorTB;
    public enum weaponDisplayed {rifle, sniper, sword };
    weaponDisplayed displayedWeapon = weaponDisplayed.sword;

    public static StatsDisplayController main;

    private void Awake()
    {
        main = this;
    }

    public void ChangeDisplayedWeapon(int newDisplay)
    {
        displayedWeapon = (weaponDisplayed)newDisplay;
        AlterStatsDisplay(PlayerData.playerStats);
    }


    public void AlterStatsDisplay(StatBlock playerStats)
    {
        string weaponsDisplayString;
        switch (displayedWeapon)
        {
            case weaponDisplayed.rifle:
                float[] rifleValues = playerStats.ReturnValues("rifle", "final");
                weaponsDisplayString = "Rifle: \n Damage: " + rifleValues[0];
                switch (rifleValues[1])
                {
                    case 0:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: Light";
                            break;
                    case 1:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: Heavy";
                            break;
                }
                switch (rifleValues[2])
                {
                    case 0:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Type: Standard";
                        break;
                    case 1:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: Direct";
                        break;
                    case 2:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: Splash";
                        break;
                    case 3:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: AP";
                        break;
                    case 4:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: True";
                        break;
                }
                weaponsDisplayString = weaponsDisplayString + "\n Ammo Count: " + rifleValues[3] + "\n Reload Time: " + rifleValues[4] + "\n Firerate: " + (1/rifleValues[5]).ToString("n2") + "rps" + "\n Range: " + rifleValues[6] + "m" + "\n Spread: " + rifleValues[7] + "°" + "\n Penertration: " + rifleValues[8];
                weaponsTB.text = weaponsDisplayString;
            break;
            case weaponDisplayed.sword:
                float[] swordValues = playerStats.ReturnValues("melee", "final");
                weaponsDisplayString = "Sword: \n Damage: " + swordValues[0];
                switch (swordValues[1])
                {
                    case 0:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: Light";
                        break;
                    case 1:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: Heavy";
                        break;
                }
                switch (swordValues[2])
                {
                    case 0:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Type: Standard";
                        break;
                    case 1:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: Direct";
                        break;
                    case 2:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: Splash";
                        break;
                    case 3:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: AP";
                        break;
                    case 4:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: True";
                        break;
                }
                weaponsDisplayString = weaponsDisplayString + "\n Attack Speed: " + swordValues[3] + "\n Combo Cooldown: " + swordValues[4] + "\n Number of Attacks: " + swordValues[5];
                weaponsTB.text = weaponsDisplayString;
                break;
            case weaponDisplayed.sniper:
                float[] sniperValues = playerStats.ReturnValues("sniper", "final");
                weaponsDisplayString = "Sniper: \n Damage: " + sniperValues[0];
                switch (sniperValues[1])
                {
                    case 0:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: Light";
                        break;
                    case 1:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: heavy";
                        break;
                }
                switch (sniperValues[2])
                {
                    case 0:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Type: Standard";
                        break;
                    case 1:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: Direct";
                        break;
                    case 2:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: Splash";
                        break;
                    case 3:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: AP";
                        break;
                    case 4:
                        weaponsDisplayString = weaponsDisplayString + "\n Damage Class: True";
                        break;
                }
                weaponsDisplayString = weaponsDisplayString + "\n Ammo Count: " + sniperValues[3] + "\n Reload Time: " + sniperValues[4] + "\n Firerate: " + (1 / sniperValues[5]).ToString("n2") + "rps" + "\n Range: " + sniperValues[6] + "m" + "\n Spread: " + sniperValues[7] + "°" + "\n Penertration: " + sniperValues[8];
                weaponsTB.text = weaponsDisplayString;
            break;
        }

        float[] baseValues = playerStats.ReturnValues("base", "final");
        float[] defenceValues = playerStats.ReturnValues("defence", "final");
        string armorDisplayString;
        armorDisplayString = "HP: " + baseValues[0] + "\n Move Speed: " + baseValues[1] + "\n View Range: " + baseValues[2] + "\n Envimental Protection: " +
                             baseValues[3] + "%\n\n Evasion Chance: " + defenceValues[0] + "% \n Graze chance: " + defenceValues[0] + "% - " + defenceValues[1] + "%\n Evasion Count: " + defenceValues[2] +
                             "\n\n Armor Value: " + defenceValues[3] + "\n Deflection Value: " + defenceValues[4] + "\n Armor Health: " + defenceValues[5];
        ArmorTB.text = armorDisplayString;
    }
    



}
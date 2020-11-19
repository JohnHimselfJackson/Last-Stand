using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SkillInfoScreen : MonoBehaviour
{
    [SerializeField]
    private Color armorColour, weaponColour;

    [SerializeField]
    private GameObject weaponTree, armorTree, armorSwap, weaponSwap, armorIcons, weaponIcons;

    public Image skillNameC, selectedSkill, skillDescriptionC;

    public TMP_Text skillN, skillD;

    //Display Selected Skill Info
    //Name
    //Image
    //Description

    public void SwapTree(int pageNum)
    {
        switch(pageNum)
        {
            case 0:
                {
                    skillNameC.color = armorColour;
                    skillDescriptionC.color = armorColour;

                    armorSwap.SetActive(false);
                    weaponSwap.SetActive(true);

                    armorTree.SetActive(true);
                    weaponTree.SetActive(false);

                    armorIcons.SetActive(true);
                    weaponIcons.SetActive(false);

                    return;
                }
            case 1:
                {
                    skillNameC.color = weaponColour;
                    skillDescriptionC.color = weaponColour;

                    armorSwap.SetActive(true);
                    weaponSwap.SetActive(false);

                    armorTree.SetActive(false);
                    weaponTree.SetActive(true);

                    armorIcons.SetActive(false);
                    weaponIcons.SetActive(true);

                    return;
                }
        }
    }

    public void SceneChange(string sceneName)
    {


        if (sceneName == "scxcZ")
        {
            if(ButtonManager.bM.currentE != null)
            {
                switch (ButtonManager.bM.currentE.myUpgrade.name)
                {
                    case "Self Sufficient Impulse Thrusters": //impulse thrusters
                        PlayerData.playerStats.eAbility = 0;
                        break;
                    case "Shield Generation": //shield;
                        PlayerData.playerStats.eAbility = 1;
                        break;
                    case "Juggernaught Mode": //juggernaught
                        PlayerData.playerStats.eAbility = 2;
                        break;
                    case "Suit Overcharge": //overcharge
                        PlayerData.playerStats.eAbility = 3;
                        break;
                    case null:
                        PlayerData.playerStats.eAbility = 4;
                        break;
                }
            }
            if (ButtonManager.bM.currentQ != null)
            {
                switch (ButtonManager.bM.currentQ.myUpgrade.name)
                {
                    case "Self Sufficient Impulse Thrusters": //impulse thrusters
                        PlayerData.playerStats.qAbility = 0;
                        break;
                    case "Shield Generation": //shield;
                        PlayerData.playerStats.qAbility = 1;
                        break;
                    case "Juggernaught Mode": //juggernaught
                        PlayerData.playerStats.qAbility = 2;
                        break;
                    case "Suit Overcharge": //overcharge
                        PlayerData.playerStats.qAbility = 3;
                        break;
                    case null:
                        PlayerData.playerStats.qAbility = 4;
                        break;
                }
            }
            SceneManager.LoadSceneAsync(sceneName);
        }
        else
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
    /*
        if (GetComponent<UpgradeLogic>().myUpgrade.name == "Self Sufficient Impulse Thrusters" ||
           GetComponent<UpgradeLogic>().myUpgrade.name == "Suit Overcharge" ||
           GetComponent<UpgradeLogic>().myUpgrade.name == "Juggernaught Mode" ||
           GetComponent<UpgradeLogic>().myUpgrade.name == "Shield Generation")*/
}

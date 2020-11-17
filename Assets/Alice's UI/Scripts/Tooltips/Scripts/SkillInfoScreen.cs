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
        SceneManager.LoadSceneAsync(sceneName);
    }
}

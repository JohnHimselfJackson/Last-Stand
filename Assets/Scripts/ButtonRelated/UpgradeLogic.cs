using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeLogic : MonoBehaviour
{
    public bool alreadyUpgraded;
    public UpgradeLogic[] prereq;
    public List<UpgradeLogic> dependents;
    public bool and;
    public string myUpgradeName;
    public Upgrade myUpgrade;
    public UpgradeInfo myInfo;
    public GameObject arrow;

    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { GetUpgrade(); });
        for (int pp = 0; pp < prereq.Length; pp++)
        {
            prereq[pp].dependents.Add(this);
        }
        ButtonClickable();
        FindMyUpgrade();
        
    }
    
    //runs on button click
    void GetUpgrade()
    {
        ButtonManager.bM.UpgradePointUsed(1);
        GetComponent<Image>().color = Color.yellow;
        alreadyUpgraded = true;
        myUpgrade.upgraded = true;
        foreach(UpgradeLogic uu in dependents)
        {
            if(uu != null)
            {
                uu.ButtonClickable();
            }
        }
        ButtonClickable();

        //add upgrade
        if(myUpgrade.myType == Upgrade.type.stats || myUpgrade.myType == Upgrade.type.multi)
        {
            for(int ii = 0; ii < myUpgrade.statChanges.Length; ii++)
            {
                float[] temp;
                switch (ii)
                {
                    case 0: // apply sword stat changes
                        temp = new float[myUpgrade.statChanges[ii].Length]; 
                        for(int jj = 0; jj < myUpgrade.statChanges[ii].Length; jj++)
                        {
                            temp[jj] = myUpgrade.statChanges[ii][jj];
                        }
                        PlayerData.playerStats.ChangeMeleeValues(temp);
                    break;
                    case 1: // aplly rifle stat changes
                        temp = new float[myUpgrade.statChanges[ii].Length];
                        for (int jj = 0; jj < myUpgrade.statChanges[ii].Length; jj++)
                        {
                            temp[jj] = myUpgrade.statChanges[ii][jj];
                        }
                        PlayerData.playerStats.ChangeRifleValues(temp);
                        break;
                    case 2://sniper logic
                        temp = new float[myUpgrade.statChanges[ii].Length];
                        for (int jj = 0; jj < myUpgrade.statChanges[ii].Length; jj++)
                        {
                            temp[jj] = myUpgrade.statChanges[ii][jj];
                        }
                        PlayerData.playerStats.ChangeSniperValues(temp);
                        break;
                    case 3://base logic
                        temp = new float[myUpgrade.statChanges[ii].Length];
                        for (int jj = 0; jj < myUpgrade.statChanges[ii].Length; jj++)
                        {
                            temp[jj] = myUpgrade.statChanges[ii][jj];
                        }
                        PlayerData.playerStats.ChangeStatValues(temp);
                        break;
                    case 4://defence logic
                        temp = new float[myUpgrade.statChanges[ii].Length];
                        for (int jj = 0; jj < myUpgrade.statChanges[ii].Length; jj++)
                        {
                            temp[jj] = myUpgrade.statChanges[ii][jj];
                        }
                        PlayerData.playerStats.ChangeDefenceValues(temp);
                        break;
                }
            }
        }
        if (myUpgrade.myType == Upgrade.type.passive)
        {
            if (myUpgrade.name == "Built in Med Suite")
            {
                PlayerData.playerStats.gotMedSuite = true;
            }
            if (myUpgrade.name == "Regenerative Materials")
            {
                PlayerData.playerStats.gotBioArmour = true;
            }

        }
        if (myUpgrade.myType == Upgrade.type.active)
        {
            if (myUpgrade.name == "Focus Laser")
            {
                PlayerData.playerStats.gotLaser = true;
            }
            if (myUpgrade.name == "High Explosives")
            {
                PlayerData.playerStats.gotGrenade = true;
            }
        }

    }
    public void ButtonClickable()
    {
        bool returnThis = true;

        if (!ButtonManager.bM.pointsAvailable(1))
        {
            returnThis = false;
        }

        if(!AndOrCheck())
        {
            returnThis = false;
        }

        if(prereq.Length == 0)
        {
            returnThis = true;
        }
        

        if (alreadyUpgraded)
        {

            returnThis = false;
            var colors = GetComponent<Button>().colors;
            colors.disabledColor = Color.green;
            GetComponent<Button>().colors = colors;
        }
        btn.interactable = returnThis;
    }
    bool AndOrCheck()
    {
        if (and)
        {
            for (int aa = 0; aa < prereq.Length; aa++)
            {
                if (!prereq[aa].alreadyUpgraded)
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            for (int aa = 0; aa < prereq.Length; aa++)
            {
                if (prereq[aa].alreadyUpgraded)
                {
                    return true;
                }
            }
            return false;
        }
    }

    void FindMyUpgrade()
    {
        if(myUpgradeName != "")
        {
            for (int uu = 0; uu < Upgrades.upgradeList.Count; uu++)
            {
                if (Upgrades.upgradeList[uu].name == myUpgradeName)
                {
                    myUpgrade = Upgrades.upgradeList[uu];
                    break;
                }
            }
            if (myUpgrade == null)
            {
                print("was unable to find upgrade " + myUpgradeName);
            }
            else
            {
                myInfo.SetUpgradeRelated();
            }

            if(myUpgrade.upgraded == true)
            {
                print("upgrade already upgraded");
                GetUpgrade();
            }
        }
        if(myUpgrade.name == "")
        {

        }
    }
    
}

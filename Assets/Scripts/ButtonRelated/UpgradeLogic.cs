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
        alreadyUpgraded = true;
        myUpgrade.upgraded = true;
        foreach(UpgradeLogic uu in dependents)
        {
            uu.ButtonClickable();
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

    }
    void ButtonClickable()
    {
        bool returnThis;
        //check upgrade points

        //check prereq
        returnThis = AndOrCheck();

        if(prereq.Length == 0)
        {
            returnThis = true;
        }
        if (alreadyUpgraded)
        {
            returnThis = false;
            var colors = GetComponent<Button>().spriteState;
            colors.disabledSprite = colors.highlightedSprite;
            GetComponent<Button>().spriteState = colors;
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

    public void FindMyUpgrade()
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
    }

    //void CreateDependentsArrows()
    //{
    //    foreach (UpgradeLogic ul in dependents)
    //    {
    //        Vector2 startButtonPos = gameObject.GetComponent<RectTransform>().anchoredPosition - new Vector2(/*gameObject.GetComponent<Image>().flexibleWidth/2*/ 120, 0);
    //        Vector2 endButtonPos = ul.GetComponent<RectTransform>().anchoredPosition + new Vector2(/*ul.GetComponent<Image>().flexibleWidth / 2*/ 120, 0);
    //        float length;
    //        Vector2 midpoint;
    //        GameObject prereqArrow;

    //        if (startButtonPos.x > endButtonPos.x)
    //        {
    //            startButtonPos = gameObject.GetComponent<RectTransform>().anchoredPosition - new Vector2(/*gameObject.GetComponent<Image>().flexibleWidth/2*/80, 0);
    //            endButtonPos = ul.GetComponent<RectTransform>().anchoredPosition + new Vector2(/*ul.GetComponent<Image>().flexibleWidth / 2*/ 80, 0);
    //            length = (endButtonPos - startButtonPos).magnitude;

    //            midpoint = (new Vector2((endButtonPos.x - startButtonPos.x) / 2, (endButtonPos.y - startButtonPos.y) / 2) - new Vector2(/*gameObject.GetComponent<Image>().flexibleWidth/2*/ 80, 0));
                
    //            prereqArrow = Instantiate<GameObject>(arrow, midpoint, Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(startButtonPos.y - endButtonPos.y, startButtonPos.x - endButtonPos.x) * Mathf.Rad2Deg - 180)));
    //            prereqArrow.transform.SetParent(this.transform);
    //            prereqArrow.GetComponent<RectTransform>().localScale = new Vector3((length / prereqArrow.GetComponent<SpriteRenderer>().bounds.size.x) * 0.7f, (length / prereqArrow.GetComponent<SpriteRenderer>().bounds.size.x) * 0.7f, 1);
    //            prereqArrow.GetComponent<RectTransform>().anchoredPosition = midpoint;

    //        }
    //        else
    //        {
    //            startButtonPos = gameObject.GetComponent<RectTransform>().anchoredPosition + new Vector2(/*gameObject.GetComponent<Image>().flexibleWidth/2*/ 80, 0);
    //            endButtonPos = ul.GetComponent<RectTransform>().anchoredPosition - new Vector2(/*ul.GetComponent<Image>().flexibleWidth / 2*/ 80, 0);
    //            length = (endButtonPos - startButtonPos).magnitude;


    //            midpoint = (new Vector2((endButtonPos.x - startButtonPos.x) / 2, (endButtonPos.y - startButtonPos.y) / 2) + new Vector2(/*gameObject.GetComponent<Image>().flexibleWidth/2*/ 80, 0));
                
    //            prereqArrow = Instantiate<GameObject>(arrow, midpoint, Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(startButtonPos.y - endButtonPos.y, startButtonPos.x - endButtonPos.x) * Mathf.Rad2Deg - 180)));
    //            prereqArrow.transform.SetParent(this.transform);
    //            prereqArrow.GetComponent<RectTransform>().localScale = new Vector3((length / prereqArrow.GetComponent<SpriteRenderer>().bounds.size.x) * 0.7f, (length / prereqArrow.GetComponent<SpriteRenderer>().bounds.size.x) * 0.7f, 1);
    //            prereqArrow.GetComponent<RectTransform>().anchoredPosition = midpoint;

    //        }
    //    }
    }


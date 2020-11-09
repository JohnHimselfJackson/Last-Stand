using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatController : MonoBehaviour
{
    public enum Stat {agility, focus, tech, vitality}
    public Stat myStat;
    public bool expanded = false;
    bool mouseOver = false;

    private GameObject[] subMenus;
    private StatDataManager sdm;
    public TMP_Text HardStatTB;
    public TMP_Text statChangeTB;
    public GameObject statNameGO;

    private int hardStat;
    private int statChange;

    private void Start()
    {
        hardStat = 5;
        sdm = FindObjectOfType<StatDataManager>();
        subMenus = FindAllSubMenus("SubMenuComponent");
        statNameGO.GetComponent<TMP_Text>().text = myStat.ToString();
        OpenCloseSubMenus();
        UpdateStatText();
        SetStatNameTBState();
    }
    private void Update()
    {
        OutClicking();
    }

    #region On Start Functions
    GameObject[] FindAllSubMenus(string subMenuTag)
    {
        List<GameObject> returnArray = new List<GameObject>();
        int noChilds = transform.childCount;
        for (int cc = 0; cc < noChilds; cc++)
        {
            if (transform.GetChild(cc).CompareTag(subMenuTag))
            {
                returnArray.Add(transform.GetChild(cc).gameObject);
            }
        }
        return returnArray.ToArray();
    }
    #endregion    

    #region SelectionRelated
    public void MainHoverOver()
    {
        mouseOver = true;
        SetStatNameTBState();
    }
    public void MainHoverOff()
    {
        mouseOver = false;
        SetStatNameTBState();
    }
    public void OnMainClick()
    {
        expanded = true;
        OpenCloseSubMenus();
        SetStatNameTBState();
    }
    void OutClicking()
    {
        if (expanded && !mouseOver && (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1)))
        {
            expanded = false;
            OpenCloseSubMenus();
            SetStatNameTBState();
        }
    }
    public void OpenCloseSubMenus()
    {
        if (expanded)
        {
            for (int mm = 0; mm < subMenus.Length; mm++)
            {
                subMenus[mm].SetActive(true);
            }
        }
        else
        {
            for (int mm = 0; mm < subMenus.Length; mm++)
            {
                subMenus[mm].SetActive(false);
            }
        }
    }
    void SetStatNameTBState()
    {
        if (mouseOver || expanded)
        {
            statNameGO.SetActive(true);
        }
        else
        {
            statNameGO.SetActive(false);
        }
    }
    #endregion

    #region Stat Interaction
    public int GetStat()
    {
        return hardStat;
    }
    
    public void SetHardStat(int newHardStat)
    {
        hardStat = newHardStat;
        UpdateStatText();
    }

    public void ChangeStatChange(int change)
    {
        if(change > 0 && sdm.freeStatPoints > 0)
        {
            statChange += change;
            sdm.freeStatPoints -= change;
            UpdateStatText();
        }
        else if (change < 0 && statChange > 0)
        {
            statChange += change;
            sdm.freeStatPoints -= change;
            UpdateStatText();
        }
    }

    public void SettleStats()
    {
        hardStat += statChange;
        statChange = 0;
        expanded = false;
        OpenCloseSubMenus();
        UpdateStatText();
    }

    void UpdateStatText()
    {
        HardStatTB.text = hardStat.ToString();
        if(statChange != 0)
        {
            statChangeTB.text = "+" + statChange.ToString();
        }
        else
        {
            statChangeTB.text = null;
        }
    }


    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
   public TMP_Text pointsLeftTB;
    public TMP_Text SkillNameTB;
    public TMP_Text SkillDescriptionTB;
    public static ButtonManager bM;
    int pointsLeft;
    int startingPoints = 20;
    public Color standradColor;

    public UpgradeLogic buttonSelected = null;
    // Start is called before the first frame update
    void Awake()
    {
        pointsLeft = startingPoints;
        bM = this;
    }
    private void Start()
    {
        UpgradePointUsed(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public UpgradeLogic[] FindButtons()
    {
        return FindObjectsOfType<UpgradeLogic>();
        
    }


    public void UpgradePointUsed(int pointsUsed)
    {
        pointsLeft -= pointsUsed;
        pointsLeftTB.text ="Points: " + pointsLeft + " / " + startingPoints;
        if(pointsLeft == 0)
        {
            foreach(UpgradeLogic uL in FindButtons())
            {
                uL.ButtonClickable();
            }
        }
    }
    public bool pointsAvailable(int pointsToCheck)
    {
        if(pointsLeft > pointsToCheck)
        {
            return true;
        }
        return false;
    }
}

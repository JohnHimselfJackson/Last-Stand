using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public TMP_Text researchPointsTB;
    private int _researchPoints;
    public int researchPoints
    {
        get
        {
            return _researchPoints;
        }
        set
        {
            _researchPoints = value;
            researchPointsTB.text = researchPoints.ToString();
        }
    }
    public TMP_Text transendencePointsTB;
    private int _transendencePoints;
    public int transendencePoints
    {
        get
        {
            return _transendencePoints;
        }
        set
        {
            _transendencePoints = value;
            transendencePointsTB.text = _transendencePoints.ToString();
        }
    }
    public TMP_Text masteryPointsTB;
    private int _masteryPoints;
    public int masteryPoints
    {
        get
        {
            return _masteryPoints;
        }
        set
        {
            _masteryPoints = value;
            masteryPointsTB.text = _masteryPoints.ToString();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        masteryPoints = 100;
        researchPoints = 100;
        transendencePoints = 100;
    }
}

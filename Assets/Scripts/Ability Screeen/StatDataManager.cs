using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDataManager : MonoBehaviour
{
    public TMP_Text freeStatTB;
    private int _freeStatPoints;
    public int freeStatPoints
    {
        get
        {
            return _freeStatPoints;
        }
        set
        {
            _freeStatPoints = value;
            freeStatTB.text = _freeStatPoints.ToString();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        freeStatPoints = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

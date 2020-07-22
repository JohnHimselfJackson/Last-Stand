using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeInfo : MonoBehaviour
{
    public UpgradeLogic myUpgradeLogic;
    public TMP_Text nameTB;
    public TMP_Text descriptionTB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetUpgradeRelated()
    {
        nameTB.text = myUpgradeLogic.myUpgrade.name;
        descriptionTB.text = myUpgradeLogic.myUpgrade.description;
    }
}

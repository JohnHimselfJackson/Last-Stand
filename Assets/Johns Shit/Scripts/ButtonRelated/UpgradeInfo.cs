using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeInfo : MonoBehaviour
{
    public UpgradeLogic myUpgradeLogic;
    public TMP_Text nameTB;
    public TMP_Text descriptionTB;

    public void SetUpgradeRelated()
    {
        nameTB.text = myUpgradeLogic.myUpgrade.name;
        descriptionTB.text = myUpgradeLogic.myUpgrade.description;
    }
}

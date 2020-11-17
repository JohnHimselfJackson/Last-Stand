using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Color standradColor;

    public UpgradeLogic buttonSelected = null;

    public UpgradeLogic[] FindButtons()
    {
        return FindObjectsOfType<UpgradeLogic>();
        
    }
}

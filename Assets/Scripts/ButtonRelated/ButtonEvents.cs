using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject upgradeInfo;
    private void Start()
    {
        upgradeInfo.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        SetInfo();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        UnSetInfo();
    }
    void SetInfo()
    {
        ButtonManager.bM.SkillNameTB.text = GetComponent<UpgradeLogic>().myUpgrade.name;
        ButtonManager.bM.SkillDescriptionTB.text = GetComponent<UpgradeLogic>().myUpgrade.description;
    }
    void UnSetInfo()
    {
        /*
        ButtonManager.bM.SkillNameTB.text = null;
        ButtonManager.bM.SkillDescriptionTB.text = null;
        */
    }
    



}

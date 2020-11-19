using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool pointerOver, activeAbility;
    public GameObject upgradeInfo;
    private void Start()
    {
        upgradeInfo.SetActive(false);
        Invoke("CheckUpgrade",0.001f);
    }
    private void Update()
    {
        if (pointerOver && activeAbility && GetComponent<UpgradeLogic>().alreadyUpgraded)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (ButtonManager.bM.currentE == this)
                {
                    ButtonManager.bM.currentE.GetComponent<Image>().color = Color.yellow;
                    ButtonManager.bM.currentE = null;
                }
                if (ButtonManager.bM.currentQ == null)
                {
                    ButtonManager.bM.currentQ = GetComponent<UpgradeLogic>();
                    ButtonManager.bM.currentQ.GetComponent<Image>().color = Color.green;

                }
                else if(ButtonManager.bM.currentQ != this)
                {
                    ButtonManager.bM.currentQ.GetComponent<Image>().color = Color.yellow;
                    ButtonManager.bM.currentQ = GetComponent<UpgradeLogic>();
                    ButtonManager.bM.currentQ.GetComponent<Image>().color = Color.green;
                }
                else
                {
                    ButtonManager.bM.currentQ = GetComponent<UpgradeLogic>();
                    ButtonManager.bM.currentQ.GetComponent<Image>().color = Color.green;
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(ButtonManager.bM.currentQ == this)
                {
                    ButtonManager.bM.currentQ.GetComponent<Image>().color = Color.yellow;
                    ButtonManager.bM.currentQ = null;
                }
                if (ButtonManager.bM.currentE == null)
                {
                    ButtonManager.bM.currentE = GetComponent<UpgradeLogic>();
                    ButtonManager.bM.currentE.GetComponent<Image>().color = Color.blue;

                }
                else if (ButtonManager.bM.currentE != this)
                {
                    ButtonManager.bM.currentE.GetComponent<Image>().color = Color.yellow;
                    ButtonManager.bM.currentE = GetComponent<UpgradeLogic>();
                    ButtonManager.bM.currentE.GetComponent<Image>().color = Color.blue;
                }
                else
                {
                    ButtonManager.bM.currentE = GetComponent<UpgradeLogic>();
                    ButtonManager.bM.currentE.GetComponent<Image>().color = Color.blue;
                }
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerOver = true;
        SetInfo();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        pointerOver = false;
        UnSetInfo();
    }
    void SetInfo()
    {
        ButtonManager.bM.SkillNameTB.text = GetComponent<UpgradeLogic>().myUpgrade.name;
        ButtonManager.bM.SkillDescriptionTB.text = GetComponent<UpgradeLogic>().myUpgrade.description;
        ButtonManager.bM.upgradeIcon.sprite = GetComponent<Image>().sprite;
    }
    void UnSetInfo()
    {
        /*
        ButtonManager.bM.SkillNameTB.text = null;
        ButtonManager.bM.SkillDescriptionTB.text = null;
        */
    }
    void CheckUpgrade()
    {
        if (GetComponent<UpgradeLogic>().myUpgrade.name == "Self Sufficient Impulse Thrusters" ||
           GetComponent<UpgradeLogic>().myUpgrade.name == "Suit Overcharge" ||
           GetComponent<UpgradeLogic>().myUpgrade.name == "Juggernaught Mode" ||
           GetComponent<UpgradeLogic>().myUpgrade.name == "Shield Generation")
        {
            activeAbility = true;
        }
    }





}

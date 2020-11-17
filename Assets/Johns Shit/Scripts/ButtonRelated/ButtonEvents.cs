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
        SetInfoActive();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (upgradeInfo.activeInHierarchy == true)
        {
            upgradeInfo.SetActive(false);
        }
    }
    void SetInfoActive()
    {
        upgradeInfo.SetActive(true);
    }
}

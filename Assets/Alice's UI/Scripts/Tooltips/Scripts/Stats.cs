using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VulpineAlice.TooltipUI
{
    public class Stats : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private float totalStatValue, currentStatValue, statPercentage, tempValue;
        [SerializeField]
        private string statName;
        [SerializeField]
        private TooltipPopUp tooltipPopUp;

        [SerializeField]
        private Image statFill;

        private void Awake()
        {
            statFill = this.GetComponentsInChildren<Image>()[1];
        }

        private void Update()
        {
            StatCalc();
        }

        private void StatCalc()
        {
            if(currentStatValue != tempValue)
            {
                tempValue = currentStatValue;
                statPercentage = ((currentStatValue -= Time.deltaTime) / totalStatValue);
                UpdateUI();
            } 
        }

        private void UpdateUI()
        {
            statFill.fillAmount = statPercentage;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltipPopUp.DisplayStatInfo(statName, statPercentage*100);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltipPopUp.HideInfo();
        }
    }
}
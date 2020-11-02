using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VulpineAlice.TooltipUI
{
    public class Stats : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public float statMax;

        [SerializeField]
        private float totalStatValue, currentStatValue, statPercentage;
        [SerializeField]
        private string statName;
        [SerializeField]
        private TooltipPopUp tooltipPopUp;

        [SerializeField]
        private Image statFill;

        private void Awake()
        {
            statFill = GetComponentsInChildren<Image>()[1];
        }
        

        public void StatCalc(float newStatValue)
        {
            statPercentage = newStatValue / statMax;
            UpdateUI();
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
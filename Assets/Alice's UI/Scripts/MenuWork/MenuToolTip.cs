using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace VulpineAlice.TooltipUI
{
    public class MenuToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private TooltipPopUp tooltipPopUp;

        [SerializeField]
        private string menuInfo;

        [SerializeField]
        private bool isSlider;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!isSlider)
            {
                tooltipPopUp.DisplayMenuInfo(menuInfo);
            }
            else
            {
                menuInfo = (GetComponent<Slider>().value * 100).ToString("F0");
                tooltipPopUp.DisplayMenuInfo(menuInfo);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltipPopUp.HideInfo();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VulpineAlice.TooltipUI
{
    public class TooltipButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private TooltipPopUp tooltipPopUp;

        [SerializeField] 
        public Item item;

        public void OnPointerEnter(PointerEventData eventData)
        {
            tooltipPopUp.DisplayItemInfo(item);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltipPopUp.HideInfo();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VulpineAlice.TooltipUI
{
    public class TooltipPopUp : MonoBehaviour
    {
        [SerializeField]
        private GameObject popupCanvasObject;
        [SerializeField]
        private RectTransform popupObject;
        [SerializeField]
        private TextMeshProUGUI infoText;
        [SerializeField]
        private Vector3 offset;
        [SerializeField]
        private float padding;

        private Canvas popupCanvas;

        private void Awake()
        {
            popupCanvas = popupCanvasObject.GetComponent<Canvas>();
        }

        private void Update()
        {
            FollowCursor();
        }

        private void FollowCursor()
        {
            if(!popupCanvasObject.activeSelf) 
            { 
                return; 
            }

            Vector3 newPos = new Vector3 (Input.mousePosition.x + (popupObject.rect.width/2), Input.mousePosition.y + offset.y, 0);
            newPos.z = 0f;

            float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + popupObject.rect.width * popupCanvas.scaleFactor / 2) - padding;
            if(rightEdgeToScreenEdgeDistance < 0)
            {
                newPos.x += rightEdgeToScreenEdgeDistance;
            }

            float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - popupObject.rect.width * popupCanvas.scaleFactor / 2) + padding;
            if(leftEdgeToScreenEdgeDistance > 0)
            {
                newPos.x += leftEdgeToScreenEdgeDistance;
            }

            float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + popupObject.rect.height * popupCanvas.scaleFactor) - padding;
            if(topEdgeToScreenEdgeDistance < 0)
            {
                newPos.y += topEdgeToScreenEdgeDistance;
            }
            popupObject.transform.position = newPos;
        }

        public void DisplayItemInfo(Item item)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<size=24>").Append(item.ColouredName).Append("</size>").AppendLine();
            builder.Append(item.GetTooltipInfoText());

            infoText.text = builder.ToString();
            infoText.alignment = TextAlignmentOptions.TopLeft;

            popupCanvasObject.SetActive(true);
            LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject);
        }

        public void DisplayStatInfo(string statName, float percentage)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<size=24>").Append(statName).Append("</size>").AppendLine();
            builder.Append(percentage);

            infoText.text = builder.ToString();
            infoText.alignment = TextAlignmentOptions.Center;

            popupCanvasObject.SetActive(true);
            LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject);
        }

        public void DisplayMenuInfo(string menuInfo)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<size=24>").Append(menuInfo).Append("</size>");

            infoText.text = builder.ToString();
            infoText.color = Color.white;
            infoText.alignment = TextAlignmentOptions.Left;

            popupCanvasObject.SetActive(true);
            LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject);
        }

        public void HideInfo()
        {
            popupCanvasObject.SetActive(false);
        }
    }

}

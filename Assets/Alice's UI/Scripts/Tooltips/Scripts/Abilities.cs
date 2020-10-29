using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace VulpineAlice.TooltipUI
{
    [CreateAssetMenu(fileName = "New Ability", menuName = "Items/Ability")]
    public class Spells : Item
    {
        [SerializeField] 
        private Rarity rarity;

        public Rarity Rarity { get { return rarity; } }
        public override string ColouredName 
        { 
            get
            {
                string hexColour = ColorUtility.ToHtmlStringRGB(rarity.TextColour);
                return $"<color=#{hexColour}>{Name}</color>";
            }
        
        }
        public override string GetTooltipInfoText()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("<color=green>[ ").Append(" ]</color>").AppendLine();
            builder.Append("Cooldown: ").Append(Cooldown).Append(" s").AppendLine();
            builder.Append("<size=15>").Append(Description).Append("</size>");

            return builder.ToString();
        }
    }
}

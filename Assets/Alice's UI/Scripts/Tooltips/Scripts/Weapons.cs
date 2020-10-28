using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace VulpineAlice.TooltipUI
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
    public class Weapons : Item
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
            //name
            //description
            //range
            //damage
            builder.Append("Range: ").Append(Range).AppendLine();
            builder.Append("Damage: ").Append(Damage).AppendLine();
            builder.Append("Damage Type: ").Append(DamageType).AppendLine();
            builder.Append("Rounds Per Second: ").Append(RoundsPerSecond).AppendLine();
            builder.Append("<size=12>").Append(Description).Append("</size>");

            return builder.ToString();
        }
    }
}

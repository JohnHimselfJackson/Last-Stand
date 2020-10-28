using System.Security.Cryptography;
using UnityEngine;

namespace VulpineAlice.TooltipUI
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField] 
        private new string name;
        [SerializeField] 
        private string description;
        [SerializeField] 
        private float cooldown, reloadSpeed;
        [SerializeField]
        private int damage;
        [SerializeField]
        private string range;
        [SerializeField]
        private string damageType;
        [SerializeField]
        private int roundsPerSecond;
        [SerializeField]
        private int totalAmmo;

        public string Name { get { return name; } }
        public abstract string ColouredName { get; }
        public string Description { get { return description; } }
        public float Cooldown { get { return cooldown; } }
        public int Damage { get { return damage; } }
        public string DamageType { get { return damageType; } }
        public int RoundsPerSecond { get { return roundsPerSecond; } }
        public int TotalAmmo { get { return totalAmmo; } }
        public float ReloadSpeed { get { return reloadSpeed; } }
        public string Range { get { return range; } }
        public abstract string GetTooltipInfoText();
    }
}

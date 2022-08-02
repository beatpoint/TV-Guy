using UnityEngine;

namespace TVGuy.Gameplay.Combat
{
    [System.Serializable]
    public struct CriticalDamageInfo
    {
        [Range(0, 100)]
        public int chance;
        [Range(0, 100)]
        public int damageModifier;

        public CriticalDamageInfo(int critChance, int critDamageModifier)
        {
            this.chance = critChance;
            this.damageModifier = critDamageModifier;
        }
    }
}

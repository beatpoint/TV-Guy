using UnityEngine;

namespace TVGuy.Gameplay.Combat
{

    [System.Serializable]
    public struct CriticalDamageHandle
    {
        [SerializeField]
        [Min(1f)]
        private float m_critModifier;

        public bool CheckForCrit(CriticalDamageInfo criticalDamageInfo)
        {
            var chance = criticalDamageInfo.chance;
            if (chance > 0 && Random.Range(0, 101) <= chance)
            {
                return true;
            }
            return false;
        }

        public Damage CalculateCriticalDamage(Damage damage, CriticalDamageInfo criticalDamageInfo)
        {
            damage.value = Mathf.FloorToInt(damage.value * m_critModifier * criticalDamageInfo.damageModifier);
            return damage;
        }
    }
}
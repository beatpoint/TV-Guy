using System.Collections.Generic;
using UnityEngine;

namespace TVGuy.Gameplay.Combat.StatusAilment
{
    [CreateAssetMenu(fileName = "StatusEffectChanceData", menuName = "TVGuy/Gameplay/Combat/Inflictions/Status Effect Chance Data")]
    public class StatusEffectChanceData : ScriptableObject
    {
        [SerializeField]
        private Dictionary<StatusEffectType, int> m_chances = new Dictionary<StatusEffectType, int>();

        public Dictionary<StatusEffectType, int> chance => m_chances;

        private void OnDisable()
        {
            foreach (var key in m_chances.Keys)
            {
                if (m_chances[key] == 0)
                {
                    m_chances.Remove(key);
                }
            }
        }

        private void Validate()
        {
            foreach (var key in m_chances.Keys)
            {
                m_chances[key] = Mathf.Clamp(m_chances[key], 0, 100);
            }
        }
    }
}
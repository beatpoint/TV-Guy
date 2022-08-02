using UnityEngine;

namespace TVGuy.Gameplay.Combat
{
    [CreateAssetMenu(fileName = "DamageData", menuName = "TVGuy/Gameplay/Combat/Damage Data")]
    public class DamageData : ScriptableObject
    {
        public Damage m_damage;
    }
}

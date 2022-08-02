using UnityEngine;

namespace TVGuy.Gameplay.Combat
{
    public enum AttackResistanceType
    {
        [HideInInspector]
        None = -1,
        Weak,
        Strong,
        Immune,
        Absorb
    }
}
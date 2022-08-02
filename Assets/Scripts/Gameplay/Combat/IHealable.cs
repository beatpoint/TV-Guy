using UnityEngine;

namespace TVGuy.Gameplay.Combat
{
    public interface IHealable
    {
        Vector2 position { get; }
        void Heal(int health);
    }
}
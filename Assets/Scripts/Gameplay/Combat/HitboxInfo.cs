using System.Collections.Generic;
using UnityEngine;

namespace TVGuy.Gameplay.Combat
{
    public struct HitboxInfo
    {
        public int targetID { get; }
        public Vector2 position { get; }
        public Invulnerability invulnerabilityLevel { get; }

        public HitboxInfo(Hitbox hitbox)
        {
            targetID = hitbox.GetInstanceID();
            position = hitbox.transform.position;
            invulnerabilityLevel = hitbox.invulnerabilityLevel;
        }
    }
}
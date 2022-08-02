using TVGuy.Gameplay.Characters;
//using TVGuy.Gameplay.Characters.Players;
using System.Collections.Generic;
using UnityEngine;

namespace TVGuy.Gameplay.Combat
{
    public interface IFlinch
    {
        void Flinch(Vector2 directionToSource, RelativeDirection damageSource, AttackSummaryInfo attackInfo);
    }
}
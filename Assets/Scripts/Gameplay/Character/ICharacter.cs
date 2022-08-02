using TVGuy.Gameplay.Characters;
using UnityEngine;

namespace TVGuy.Gameplay
{
    public interface ICharacter
    {
        Rigidbody2D physics { get; }
    }
}
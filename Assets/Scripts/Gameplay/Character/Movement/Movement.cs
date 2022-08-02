using TVGuy.Gameplay.Characters.Movement;
using UnityEngine;

namespace TVGuy.Gameplay
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField]
        protected MovementData m_data;

        public abstract void MoveTowards(Vector2 direction/*, float speed*/);
        public abstract void Stop();
    }
}

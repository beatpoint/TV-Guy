using Spine.Unity;
using UnityEngine;

namespace TVGuy.Gameplay.Characters.Combat
{
    [CreateAssetMenu(fileName = "AttackData", menuName = "TVGuy/Gameplay/Character/Attack Data")]
    public class AttackData : BehaviorData
    {
        [SerializeField]
        private AnimationReferenceAsset m_attackAnimation;
        public AnimationReferenceAsset attackAnimation => m_attackAnimation;

        [SerializeField]
        private float m_damage;
        public float damage => m_damage;

    }
}

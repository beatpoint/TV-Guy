using Spine.Unity;
using UnityEngine;

namespace TVGuy.Gameplay.Characters
{
    public class BehaviorData : ScriptableObject
    {
        [SerializeField]
        private AnimationReferenceAsset m_idleAnimation;
        public AnimationReferenceAsset idleAnimation => m_idleAnimation;
    }
}

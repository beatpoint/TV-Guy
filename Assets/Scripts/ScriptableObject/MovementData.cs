using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TVGuy.Gameplay.Characters.Movement
{
    [CreateAssetMenu(fileName = "MovementData", menuName = "TVGuy/Gameplay/Character/Movement Data")]
    public class MovementData : ScriptableObject
    {
        [SerializeField]
        private SkeletonDataAsset m_skeletonDataAsset;
        public SkeletonDataAsset skeletonDataAsset => m_skeletonDataAsset;
        [SerializeField]
        private AnimationReferenceAsset m_moveAnimation;
        public AnimationReferenceAsset moveAnimation => m_moveAnimation;
        [SerializeField]
        private AnimationReferenceAsset m_idleAnimation;
        public AnimationReferenceAsset idleAnimation => m_idleAnimation;

        [SerializeField]
        private float m_speed; //Target speed we want the player to reach.
        public float speed => m_speed;
        [SerializeField]
        private float m_maxSpeed; //Target speed we want the player to reach.
        public float maxSpeed => m_maxSpeed;
        [SerializeField]
        private float m_velPower;
        public float velPower => m_velPower;
        [SerializeField]
        private float m_runAccelAmount;
        public float runAccelAmount => m_runAccelAmount;
        [SerializeField]
        private float m_runDeccelAmount;
        public float runDeccelAmount => m_runDeccelAmount;
        [SerializeField, Range(0.01f, 1)]
        private float m_accelInAir; //Multipliers applied to acceleration rate when airborne.
        public float accelInAir => m_accelInAir;
        [SerializeField, Range(0.01f, 1)]
        private float m_deccelInAir;
        public float deccelInAir => m_deccelInAir;
        [SerializeField]
        private bool m_doConserveMomentum;
        public bool doConserveMomentum => m_doConserveMomentum;
    }
}

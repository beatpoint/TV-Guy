using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using TVGuy.Event;
using TVGuy.Gameplay.Characters.Combat;
using UnityEngine;

namespace TVGuy.Gameplay
{
    [RequireComponent(typeof(CooldownTimer))]
    public abstract class Attack : MonoBehaviour
    {
        [SerializeField]
        protected SkeletonAnimation m_animation;
        [SerializeField]
        protected Rigidbody2D m_rigidbody2D;
        [SerializeField]
        protected List<AttackData> m_data;
        [SerializeField]
        protected SkeletonRootMotion m_rootMotion;

        protected CooldownTimer m_cooldownTimer;

        protected bool m_isAttacking;
        protected int m_attackCount;

        public bool isAttacking => m_isAttacking;

        public abstract void Execute(/*Vector2 direction*//*, float speed*/);
        public abstract void Stop();

        public abstract void OnCooldownStart(object sender, EventActionArgs eventArgs);
        public abstract void OnCooldownEnd(object sender, EventActionArgs eventArgs);

        protected void Awake()
        {
            m_cooldownTimer = GetComponent<CooldownTimer>();
            m_cooldownTimer.CooldownStart += OnCooldownStart;
            m_cooldownTimer.CooldownEnd += OnCooldownEnd;
        }
    }
}

using Spine.Unity;
using System.Collections;
using TVGuy.Event;
using UnityEngine;

namespace TVGuy.Gameplay
{
    public class GroundAttack : Attack
    {
        public override void OnCooldownStart(object sender, EventActionArgs eventArgs) => m_attackCount++;
        public override void OnCooldownEnd(object sender, EventActionArgs eventArgs) => m_attackCount = 0;

        public override void Execute(/*Vector2 direction*/)
        {
            if (!m_isAttacking)
            {
                StartCoroutine(AttackRoutine());
            }
        }

        public override void Stop()
        {
            if (m_animation.AnimationState.GetCurrent(0).Animation != m_data[m_attackCount].idleAnimation.Animation)
            {
                m_animation.AnimationState.SetAnimation(0, m_data[m_attackCount].idleAnimation, true);
            }

            m_rigidbody2D.velocity = Vector2.zero;
        }

        private IEnumerator AttackRoutine()
        {
            m_isAttacking = true;
            m_rootMotion.rootMotionScaleX = 1;
            m_animation.AnimationState.SetAnimation(0, m_data[m_attackCount].attackAnimation, false);
            yield return new WaitUntil(() => m_animation.AnimationState.GetCurrent(0).IsComplete);
            m_isAttacking = false;
            m_rootMotion.rootMotionScaleX = 0;
            m_animation.AnimationState.SetAnimation(0, m_data[m_attackCount].idleAnimation, true);
            m_cooldownTimer.StartCooldown();
            m_attackCount = /*!m_cooldownTimer.inCooldown ||*/ m_attackCount > m_data.Count - 1 ? 0 : m_attackCount;
            yield return null;
        }
    }
}

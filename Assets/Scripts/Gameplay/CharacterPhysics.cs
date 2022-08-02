using TVGuy.Gameplay.Physics;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TVGuy.Systems;

namespace TVGuy.Gameplay
{
    public class CharacterPhysics : MonoBehaviour
    {
        [SerializeField]
        private bool m_useCoyoteTime;
        [SerializeField]
        private CoyoteTimeModule m_coyoteTime;
        [SerializeField]
        private RangeFloat m_acceptableWalkableAngle;
        [SerializeField]
        private CollisionDetector m_legCollision;
        [SerializeField]
        private Collider2D m_legCollider;
        [SerializeField]
        private LayerMask m_legColliderLayerMask;

        private ColliderIntersectDetector m_legColliderDetector;
        private float m_groundAngle;

        private bool m_onWalkableGround;
        private bool m_inContactWithGround;
        public bool inContactWithGround => m_inContactWithGround;

        private Vector2 velocity;
        public void UpdatePhysics()
        {
            EvaluateGroundedness();
        }

        private void UseCoyoteTime()
        {

            if (m_coyoteTime.isAvailable)
            {
                m_onWalkableGround = true;
                m_coyoteTime.Start();
            }
            else
            {
                m_onWalkableGround = false;
            }
        }

        private void EvaluateGroundedness()
        {
            //This is where all started 
            if (m_legColliderDetector != null && m_legColliderDetector.IsIntersecting(m_legCollider))
            {
                m_onWalkableGround = false;
                m_inContactWithGround = false;
            }

            if (m_legCollider.IsTouchingLayers(m_legColliderLayerMask) && velocity.y <= 0.1f)
            {
                m_inContactWithGround = true;
                if (m_acceptableWalkableAngle.InRange(m_groundAngle))
                {
                    m_onWalkableGround = true;
                    m_coyoteTime.Reset();
                }
                else
                {
                    if (m_useCoyoteTime)
                    {
                        UseCoyoteTime();
                    }
                    else
                    {
                        m_onWalkableGround = false;
                    }
                }
            }
            else
            {
                m_inContactWithGround = false;
                if (m_useCoyoteTime)
                {
                    UseCoyoteTime();
                }
                else
                {
                    m_onWalkableGround = false;
                }
            }
        }

        private void Awake()
        {
            m_inContactWithGround = true;
            m_onWalkableGround = true;
            m_legColliderDetector = GetComponentInChildren<CapsuleColliderDetector>();
            m_legColliderLayerMask = Physics2D.GetLayerCollisionMask(m_legCollider.gameObject.layer);
        }

        protected void Update()
        {
            if (m_useCoyoteTime)
            {
                m_coyoteTime.Update(Time.deltaTime);
            }
            EvaluateGroundedness();
        }
    }
}

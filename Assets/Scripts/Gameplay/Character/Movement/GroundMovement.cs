using UnityEngine;
using TVGuy.Gameplay.Characters.Movement;
using Spine.Unity;

namespace TVGuy.Gameplay
{
    [AddComponentMenu("TVGuy/Gameplay/Movement/Ground Movement")]
    public class GroundMovement : Movement
    {
        [SerializeField]
        private SkeletonAnimation m_animation;
        [SerializeField]
        protected Rigidbody2D m_rigidbody2D;
        protected float m_targetSpeed;
        protected float m_speedDif;
        protected float m_accelRate;
        protected float m_movement;

        //[SerializeField]
        //protected float m_runMaxSpeed; //Target speed we want the player to reach.
        //protected float m_runAcceleration; //Time (approx.) time we want it to take for the player to accelerate from 0 to the runMaxSpeed.
        //[HideInInspector] protected float m_runAccelAmount; //The actual force (multiplied with speedDiff) applied to the player.
        //protected float m_runDecceleration; //Time (approx.) we want it to take for the player to accelerate from runMaxSpeed to 0.
        //[HideInInspector] protected float m_runDeccelAmount; //Actual force (multiplied with speedDiff) applied to the player .
        //[SerializeField]
        //protected float m_velPower;
        public override void MoveTowards(Vector2 direction/*, float speed*/)
        {
            if (direction.x != 0)
            {
                if (m_animation.AnimationState.GetCurrent(0).Animation != m_data.moveAnimation.Animation)
                {
                    m_animation.AnimationState.SetAnimation(0, m_data.moveAnimation, true);
                }

                //var groundDirection = new Vector2(Mathf.Sign(direction.x), 0);
                //Debug.Log("Ground Direction " + groundDirection);
                ////m_rigidbody2D.SetVelocity(groundDirection * speed);
                //m_targetSpeed = groundDirection.x * m_data.speed;
                //Debug.Log("Target Speed " + m_targetSpeed);
                //m_speedDif = m_targetSpeed - m_rigidbody2D.velocity.x;
                //Debug.Log("Speed Dif " + m_speedDif);
                //m_accelRate = (Mathf.Abs(m_targetSpeed) > 0.01f) ? m_runAccelAmount : m_runDeccelAmount;
                //Debug.Log("Accel Rate " + m_accelRate);
                //m_movement = Mathf.Pow(Mathf.Abs(m_speedDif) * 0.2f, m_data.velPower) * Mathf.Sign(m_speedDif);
                //Debug.Log("Movement Speed " + m_movement);

                //m_rigidbody2D.AddForce(m_movement * Vector2.right);
                //Calculate the direction we want to move in and our desired velocity
                float targetSpeed = direction.x * m_data.maxSpeed;

                #region Calculate AccelRate
                float accelRate;

                //Gets an acceleration value based on if we are accelerating (includes turning) 
                //or trying to decelerate (stop). As well as applying a multiplier if we're air borne.
                //if (LastOnGroundTime > 0)
                //    accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? m_data.runAccelAmount : m_data.runDeccelAmount;
                //else
                //    accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? m_data.runAccelAmount * m_data.accelInAir : m_data.runDeccelAmount * m_data.deccelInAir;
                accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? m_data.runAccelAmount : m_data.runDeccelAmount;
                #endregion

                //Not used since no jump implemented here, but may be useful if you plan to implement your own
                /* 
                #region Add Bonus Jump Apex Acceleration
                //Increase are acceleration and maxSpeed when at the apex of their jump, makes the jump feel a bit more bouncy, responsive and natural
                if ((IsJumping || IsWallJumping || _isJumpFalling) && Mathf.Abs(RB.velocity.y) < Data.jumpHangTimeThreshold)
                {
                    accelRate *= Data.jumpHangAccelerationMult;
                    targetSpeed *= Data.jumpHangMaxSpeedMult;
                }
                #endregion
                */

                #region Conserve Momentum
                //We won't slow the player down if they are moving in their desired direction but at a greater speed than their maxSpeed
                if (m_data.doConserveMomentum && Mathf.Abs(m_rigidbody2D.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(m_rigidbody2D.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f /*&& LastOnGroundTime < 0*/)
                {
                    //Prevent any deceleration from happening, or in other words conserve are current momentum
                    //You could experiment with allowing for the player to slightly increae their speed whilst in this "state"
                    accelRate = 0;
                }
                #endregion

                //Calculate difference between current velocity and desired velocity
                float speedDif = targetSpeed - m_rigidbody2D.velocity.x;
                //Calculate force along x-axis to apply to thr player

                float movement = speedDif * accelRate;

                //Convert this to a vector and apply to rigidbody
                m_rigidbody2D.AddForce(movement * Vector2.right, ForceMode2D.Force);

                /*
                 * For those interested here is what AddForce() will do
                 * RB.velocity = new Vector2(RB.velocity.x + (Time.fixedDeltaTime  * speedDif * accelRate) / RB.mass, RB.velocity.y);
                 * Time.fixedDeltaTime is by default in Unity 0.02 seconds equal to 50 FixedUpdate() calls per second
                */
            }
        }

        public override void Stop()
        {
            if (m_animation.AnimationState.GetCurrent(0).Animation != m_data.idleAnimation.Animation)
            {
                m_animation.AnimationState.SetAnimation(0, m_data.idleAnimation, true);
            }
            //m_rigidbody2D.AddForce(Vector2.zero, ForceMode2D.Force);
            m_rigidbody2D.velocity = Vector2.zero;
        }

        private void OnValidate()
        {
            //m_runAccelAmount = (50 * m_runAcceleration) / m_data.maxSpeed;
            //Debug.Log("m_runAccelAmount " + m_runAccelAmount);
            //m_runDeccelAmount = (50 * m_runDecceleration) / m_data.maxSpeed;
            //Debug.Log("m_runDeccelAmount " + m_runDeccelAmount);

            //#region Variable Ranges
            //m_runAcceleration = Mathf.Clamp(m_runAcceleration, 0.01f, m_data.maxSpeed);
            //m_runDecceleration = Mathf.Clamp(m_runDecceleration, 0.01f, m_data.maxSpeed);
            //#endregion
        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidbody2D;
    [SerializeField]
    private PlayerAnimation m_animation;
    [SerializeField]
    private CharacterState m_state;
    [SerializeField]
    private Vector2 m_jumpForce;
    [SerializeField]
    private float m_runSpeed;
    [SerializeField]
    private Vector2 m_knockbackForce;
    [SerializeField]
    private GroundChecker m_groundChecker;
    [SerializeField]
    private bool m_canDoubleJump;
    private bool m_hasDoubleJumped;
    private bool m_hasJumped;
    private bool m_isFlinching;


    //private PlayerState m_playerState;
    //private PlayerGroundnessState m_groundnessState;
    private FacingPositon m_facing;

    //public enum PlayerState
    //{
    //    Idle,
    //    Walking,
    //    Running,
    //    Jumping,
    //    Attacking,
    //    Flinching,
    //    Dead
    //}
    //public enum PlayerGroundnessState
    //{
    //    OnAir,
    //    OnGround,
    //    OnwWater
    //}

    public enum FacingPositon
    {
        Left,
        Right
    }

    public void Jump()
    {
        if (!m_isFlinching)
        {
            switch (m_state.GetGroundnessState())
            {
                case CharacterState.GroundnessState.OnAir:
                    if (m_canDoubleJump && !m_hasDoubleJumped && m_hasJumped)
                    {
                        m_hasDoubleJumped = true;
                        m_animation.IsDoubleJumping(true);
                        m_rigidbody2D.linearVelocity = Vector2.zero;
                        m_rigidbody2D.AddForce(new Vector2(m_facing == FacingPositon.Right ? Vector2.right.x * m_jumpForce.x : Vector2.left.x * m_jumpForce.x, m_jumpForce.y));
                    }
                    break;
                case CharacterState.GroundnessState.OnGround:
                    m_state.ChangeState(CharacterState.State.Jumping);
                    m_animation.IsRunning(false);
                    m_animation.IsJumping(true);
                    m_rigidbody2D.AddForce(new Vector2(m_facing == FacingPositon.Right ? Vector2.right.x * m_jumpForce.x : Vector2.left.x * m_jumpForce.x, m_jumpForce.y));
                    //m_groundnessState = PlayerGroundnessState.OnAir;
                    m_state.ChangeGroundnessState(CharacterState.GroundnessState.OnAir);
                    m_hasJumped = true;
                    break;
                case CharacterState.GroundnessState.OnwWater:
                    break;
                default:
                    break;
            }
        }
    }

    public void JumpStop()
    {
        m_hasJumped = false;
        m_state.ChangeGroundnessState(CharacterState.GroundnessState.OnGround);
        m_state.ChangeState(CharacterState.State.Idle);
        m_animation.IsJumping(false);
        if (m_hasDoubleJumped)
        {
            m_hasDoubleJumped = false;
            m_animation.IsDoubleJumping(false);
        }
    }

    public void Walk(Vector2 moveDirection)
    {
    }

    //public void Run(Vector2 moveDirection)
    //{
    //    m_rigidbody2D.AddForce(new Vector2((moveDirection.x * m_runSpeed), m_rigidbody2D.linearVelocityY));
    //}

    public void RunStop()
    {
        //m_rigidbody2D.AddForce(Vector2.zero);
        if (m_state.CurrentState() != CharacterState.State.Idle)
        {
            m_rigidbody2D.linearVelocity = Vector2.zero;
            m_animation.IsRunning(false);
            m_state.ChangeState(CharacterState.State.Idle);
        }
    }

    public void SetMoveDirection(Vector2 moveDirection)
    {
        m_facing = moveDirection.x >= 0 ? FacingPositon.Right : FacingPositon.Left;
        this.transform.localScale = m_facing == FacingPositon.Right ? Vector3.one : new Vector3(-1, 1, 1);
    }

    public void SetFlinchStatus(bool condition)
    {
        m_isFlinching = condition;
    }

    public void Knockback()
    {
        m_rigidbody2D.linearVelocity = Vector2.zero;
        m_rigidbody2D.AddForce(new Vector2(m_knockbackForce.x * -this.transform.localScale.x, m_knockbackForce.y));
    }

    private void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (m_state.CurrentState())
        {
            case CharacterState.State.Idle:
                //Debug.Log("Player is not moving.");
                m_animation.IsRunning(false);
                break;

            case CharacterState.State.Walking:
                Debug.Log("Player is walking slowly.");
                break;

            case CharacterState.State.Running:
                if (m_state.GetGroundnessState() == CharacterState.GroundnessState.OnGround && !m_isFlinching)
                {
                    //Debug.Log("Player is running fast! " + (m_facing == FacingPositon.Right ? Vector2.right.x : Vector2.left.x));
                    //m_rigidbody2D.AddForce(new Vector2((m_facing == FacingPositon.Right ? Vector2.right.x * m_runSpeed : Vector2.left.x * m_runSpeed), m_rigidbody2D.linearVelocityY) /** Time.deltaTime*/);
                    m_rigidbody2D.linearVelocity = new Vector2((m_facing == FacingPositon.Right ? Vector2.right.x * m_runSpeed : Vector2.left.x * m_runSpeed) * Time.deltaTime, m_rigidbody2D.linearVelocityY);
                    m_animation.IsRunning(true);
                }
                break;

            case CharacterState.State.Jumping:
                //Debug.Log("Player is in the air.");
                break;

            case CharacterState.State.Attacking:
                Debug.Log("Player is attacking!");
                break;

            case CharacterState.State.Flinching:
                Debug.Log("Player is flinching!");
                break;

            case CharacterState.State.Dead:
                Debug.Log("Game Over. Player is dead.");
                break;

            default:
                Debug.LogWarning("Unknown player state.");
                break;
        }
    }
}

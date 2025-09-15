using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimation m_animation;
    [SerializeField]
    private Vector2 m_force;
    [SerializeField]
    private int m_basicAttackCount;
    private int m_basicAttackCounter;
    private bool m_canAttack = true;
    private CharacterState m_state;
    private PlayerMovement m_movement;
    private Rigidbody2D m_rigidbody2D;

    public void AddCombatVelocity()
    {
        m_rigidbody2D.AddForce(new Vector2(m_movement.GetFacingPositon() == PlayerMovement.FacingPositon.Right ? m_force.x : -m_force.x, m_force.y));
    }

    public void StopCombatVelocity()
    {
        m_rigidbody2D.linearVelocity = Vector2.zero;
    }

    public void BasicAttack()
    {

        //m_basicAttackCounter = m_basicAttackCounter >= m_basicAttackCount ? m_basicAttackCounter++ : 0;
        m_canAttack = false;
        if (m_basicAttackCounter < m_basicAttackCount)
        {
            m_basicAttackCounter++;
        }
        else
        {
            m_basicAttackCounter = 0;
        }
        m_animation.IsAttacking(true, m_basicAttackCounter);
        //return m_basicAttackCounter;
    }

    public void StopAttacking()
    {
        m_animation.IsAttacking(false, 0);
        m_canAttack = true;
        m_basicAttackCounter = 0;
        m_state.ChangeState(CharacterState.State.Idle);
    }

    public bool CanAttack()
    {
        return m_canAttack;
    }

    public void AllowAttack()
    {
        m_canAttack = true;
    }

    private void Awake()
    {
        m_state = GetComponent<CharacterState>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_movement = GetComponent<PlayerMovement>();
    }
}

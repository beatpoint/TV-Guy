using UnityEngine;
using UnityEngine.InputSystem;
using TVGuy.Gameplay;
using TVGuy.Gameplay.Characters;

public class PlayerController : MonoBehaviour
{
    private PlayerControlIA m_playerControlIA;

    private Vector2 m_moveDirection;

    private InputAction m_move;
    private InputAction m_jump;
    private InputAction m_meleeAttack;

    [SerializeField]
    private Character m_character;
    [SerializeField]
    private Movement m_movement;
    [SerializeField]
    private Attack m_attack;
    [SerializeField]
    private TransformTurnHandle m_turnHandle;

    private bool m_isMoving;

    private void OnEnable()
    {
        m_move = m_playerControlIA.Player.Move;
        m_move.Enable();
        m_move.canceled += Idle;
        m_move.performed += Move;

        m_jump = m_playerControlIA.Player.Jump;
        m_jump.Enable();
        m_jump.performed += Jump;

        m_meleeAttack = m_playerControlIA.Player.MeleeAttack;
        m_meleeAttack.Enable();
        m_meleeAttack.performed += MeleeAttack;
    }

    private void OnDisable()
    {
        m_move.Disable();
        m_jump.Disable();
        m_meleeAttack.Disable();
    }

    private void Awake()
    {
        m_playerControlIA = new PlayerControlIA();
    }

    private void FixedUpdate()
    {
        if (/*m_isMoving &&*/ !m_attack.isAttacking)
        {
            m_moveDirection = m_move.ReadValue<Vector2>();
            if (m_moveDirection.x != 0)
            {
                m_movement.MoveTowards(m_moveDirection);
                Debug.Log("Moving " + m_moveDirection);
            }
            if (m_character.facing == HorizontalDirection.Right && m_moveDirection.x == -1 || m_character.facing == HorizontalDirection.Left && m_moveDirection.x == 1)
            {
                Debug.Log("Turn Character");
                m_turnHandle.Execute();
            }
        }
    }
    private void Idle(InputAction.CallbackContext context)
    {
        if (!m_attack.isAttacking)
        {
            m_isMoving = false;
            m_movement.Stop();
        }
    }

    private void Move(InputAction.CallbackContext context)
    {
        m_isMoving = true;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
    }
    private void MeleeAttack(InputAction.CallbackContext context)
    {
        m_isMoving = false;
        m_attack.Execute();
    }
}

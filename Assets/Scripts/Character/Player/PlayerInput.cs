using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private CharacterState m_state;
    [SerializeField] 
    private PlayerMovement m_movement;

    //private UnityEngine.InputSystem.PlayerInput m_input;

    private Vector2 moveInput;


    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (m_state.CurrentState() != CharacterState.State.Flinching)
        {
            if (moveInput == Vector2.zero)
            {
                Debug.Log($"Move Input: {moveInput}");
                if (m_state.CurrentState() != CharacterState.State.Idle)
                {
                    m_state.ChangeState(CharacterState.State.Idle);
                }
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && m_state.CurrentState() != CharacterState.State.Flinching)
        {
            Debug.Log("Jump Input Pressed");
            m_movement.Jump();
        }
    }
    public void OnBasicAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("I'm attacking MORTY!");
        }
    }

    //private void OnControlsChanged(UnityEngine.InputSystem.PlayerInput input)
    //{
    //    // Check which control scheme is now active
    //    if (input.currentControlScheme == "Gameplay Keyboard")
    //    {
    //        m_input.SwitchCurrentActionMap("Gameplay Controller");
    //    }
    //    else if (input.currentControlScheme == "Gameplay Controller")
    //    {
    //        m_input.SwitchCurrentActionMap("Gameplay Keyboard");
    //    }
    //}

    //void OnEnable()
    //{
    //    // Subscribe to the event that fires when the control scheme changes
    //    m_input.onControlsChanged += OnControlsChanged;
    //}

    //void OnDisable()
    //{
    //    // Unsubscribe to prevent memory leaks
    //    m_input.onControlsChanged -= OnControlsChanged;
    //}

    //private void Awake()
    //{
    //    m_input = GetComponent<UnityEngine.InputSystem.PlayerInput>();
    //}

    // Update is called once per frame
    void Update()
    {
        if (moveInput.x != 0 && m_state.CurrentState() != CharacterState.State.Flinching)
        {
            Debug.Log($"Move Input: {moveInput}");
            m_movement.SetMoveDirection(moveInput.x > 0 ? Vector2.right : Vector2.left);
            m_state.ChangeState(CharacterState.State.Running);
        }
    }
}

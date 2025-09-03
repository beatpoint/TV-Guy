using UnityEngine;
using UnityEngine.Events;

public class GroundChecker : MonoBehaviour
{
    [SerializeField]
    private Transform m_groundCheckpoint;
    [SerializeField]
    private LayerMask m_groundLayer;
    [SerializeField]
    private UnityEvent m_onGroundTouch;

    public bool IsGrounded()
    {
        Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
        return Physics2D.BoxCast(m_groundCheckpoint.position, groundCheckSize, 0f, Vector2.down, 0.1f, m_groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGrounded())
            m_onGroundTouch.Invoke();
    }
}

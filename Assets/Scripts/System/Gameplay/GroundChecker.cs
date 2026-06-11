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
    [SerializeField]
    private UnityEvent m_onGroundUntouch;

    private Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    private float castDistance = 0.1f;

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.green;

        Vector2 origin = m_groundCheckpoint.position;

        // Starting box
        Gizmos.DrawWireCube(origin, groundCheckSize);

        // Ending box after cast
        Vector2 endPosition = origin + Vector2.down * castDistance;
        Gizmos.DrawWireCube(endPosition, groundCheckSize);

        // Optional line between them
        Gizmos.DrawLine(origin, endPosition);
    }

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        m_onGroundUntouch.Invoke();
    }
}

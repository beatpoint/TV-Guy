using UnityEngine;

public class PatrolVisualizer : MonoBehaviour
{
    [SerializeField] private Color m_pathColor = Color.green;
    [SerializeField] private Color m_pointColor = Color.yellow;
    [SerializeField] private float m_circleRadius = 0.25f;
    [SerializeField] private bool m_loopPath = true;

    [SerializeField] private Vector2[] m_localPatrolPoints;

    private Vector2 m_startPosition;

    private void Awake()
    {
        m_startPosition = transform.position;
    }

    private void OnDrawGizmos()
    {
        if (m_localPatrolPoints == null || m_localPatrolPoints.Length == 0) return;

        Vector2 anchor = Application.isPlaying ? m_startPosition : (Vector2)transform.position;

        // 1. Draw Path Lines
        Gizmos.color = m_pathColor;
        for (int i = 0; i < m_localPatrolPoints.Length - 1; i++)
        {
            Vector2 currentWorldPoint = anchor + m_localPatrolPoints[i];
            Vector2 nextWorldPoint = anchor + m_localPatrolPoints[i + 1];
            Gizmos.DrawLine(currentWorldPoint, nextWorldPoint);
        }

        if (m_loopPath && m_localPatrolPoints.Length > 1)
        {
            Vector2 lastWorldPoint = anchor + m_localPatrolPoints[m_localPatrolPoints.Length - 1];
            Vector2 firstWorldPoint = anchor + m_localPatrolPoints[0];
            Gizmos.DrawLine(lastWorldPoint, firstWorldPoint);
        }

        // 2. Draw Pure 2D Flat Circles
        Gizmos.color = m_pointColor;
        foreach (Vector2 localPoint in m_localPatrolPoints)
        {
            Vector2 worldPoint = anchor + localPoint;
            Draw2DCircle(worldPoint, m_circleRadius);
        }
    }

    private void Draw2DCircle(Vector2 center, float radius)
    {
        int segments = 20; // Increase for smoother circles
        float angleStep = 360f / segments;
        Vector2 prevPoint = center + new Vector2(radius, 0f);

        for (int i = 1; i <= segments; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector2 nextPoint = center + new Vector2(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);

            Gizmos.DrawLine(prevPoint, nextPoint);
            prevPoint = nextPoint;
        }
    }
}
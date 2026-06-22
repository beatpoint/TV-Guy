using UnityEngine;
using static PlayerMovement;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    protected Transform m_target;
    [SerializeField]
    protected float m_moveSpeed;
    [SerializeField]
    protected float m_detectionRadius;

    protected CharacterState m_state;

    protected virtual void Awake()
    {
        m_state = GetComponent<CharacterState>();
    }

    protected virtual void Update()
    {
        if (m_target == null && PlayerMovement.Instance != null)
        {
            m_target = PlayerMovement.Instance;
        }
    }
}

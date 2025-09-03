using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    protected GameObject m_characterObject;
    [SerializeField]
    protected Collider2D m_hitboxCollider;
    [SerializeField]
    protected float m_maxHealth;
    protected float m_currentHealth;
    [SerializeField]
    protected float m_flinchTimer;
    [SerializeField]
    protected float m_invurnerableTimer;

    [SerializeField]
    protected UnityEvent m_takenDamageEvent;

    protected Transform m_damageLocation;
    public void TakeDamage(float damage, Transform damageLocation)
    {
        m_currentHealth -= damage;
        m_damageLocation = damageLocation;
        m_takenDamageEvent.Invoke();
    }
}

using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private float m_damageValue;

    private Collider2D m_hurtboxCollider;

    private void Awake()
    {
        m_hurtboxCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(m_damageValue, this.transform);
        }
    }
}

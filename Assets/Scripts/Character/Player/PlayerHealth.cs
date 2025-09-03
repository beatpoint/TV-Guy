using System.Collections;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField]
    private PlayerAnimation m_animation;
    [SerializeField]
    private CharacterState m_state;
    [SerializeField]
    private PlayerMovement m_movement;
    [SerializeField]
    private ParticleSystem m_invincibilityFX;

    public void PlayerTakeDamage()
    {
        m_movement.SetMoveDirection(transform.position.x <= m_damageLocation.position.x ? Vector2.right : Vector2.left);

        StartCoroutine(FlinchRuutine());
        if (m_currentHealth <= 0f)
        {
            Die();
        }
    }

    private IEnumerator FlinchRuutine()
    {
        m_state.ChangeState(CharacterState.State.Flinching);
        m_movement.SetFlinchStatus(true);
        m_animation.ResetParameters();
        m_movement.Knockback();
        m_hitboxCollider.enabled = false;
        m_animation.IsFlinching(true);
        m_animation.Flinch();
        yield return new WaitForSeconds(m_flinchTimer);
        m_invincibilityFX.Play();
        m_animation.IsFlinching(false);
        m_movement.SetFlinchStatus(false);
        m_state.ChangeState(CharacterState.State.Idle);
        yield return new WaitForSeconds(m_invurnerableTimer);
        m_hitboxCollider.enabled = true;
        yield return null;
    }

    private void Die()
    {
        m_characterObject.SetActive(false);
    }

    private void Start()
    {
        m_currentHealth = m_maxHealth;
    }
}

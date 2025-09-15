using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    #region Movement
    public void IsJumping(bool condition)
    {
        m_animator.SetBool("isJumping", condition);
        if (condition)
            m_animator.Play("PlayerJump");
    }

    public void IsDoubleJumping(bool condition)
    {
        m_animator.SetBool("isDoubleJumping", condition);
    }

    public void IsFalling(bool condition)
    {
        m_animator.SetBool("isFalling", condition);
    }

    public void IsRunning(bool condition)
    {
        m_animator.SetBool("isRunning", condition);
    }

    public void IsFlinching(bool condition)
    {
        m_animator.SetBool("isFlinching", condition);
    }

    public void Flinch()
    {
        m_animator.Play("PlayerHit");
    }

    public void IsGrounded(bool condition)
    {
        m_animator.SetBool("isGrounded", condition);
    }
    #endregion

    #region Combat
    public void IsAttacking(bool condition, int count)
    {
        m_animator.SetBool("isAttacking", condition);
        m_animator.SetInteger("attackCounter", count);

    }
    #endregion
    public void ResetParameters()
    {
        m_animator.SetBool("isRunning", false);
        m_animator.SetBool("isJumping", false);
        m_animator.SetBool("isDoubleJumping", false);
        m_animator.SetBool("isFlinching", false);
        m_animator.SetBool("isAttacking", false);
    }
}

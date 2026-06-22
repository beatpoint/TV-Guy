using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    protected Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    #region Movement

    public void IsFlinching(bool condition)
    {
        m_animator.SetBool("isFlinching", condition);
    }

    public void IsGrounded(bool condition)
    {
        m_animator.SetBool("isGrounded", condition);
    }

    public void IsMoving(bool condition)
    {
        m_animator.SetBool("isMoving", condition);
    }
    #endregion

    #region Combat
    public void IsAttacking(bool condition, int count)
    {
        m_animator.SetBool("isAttacking", condition);
        m_animator.SetInteger("attackCounter", count);
    }
    #endregion

    public void IsDead(bool condition)
    {
        m_animator.SetBool("isDead", condition);
    }

    public void ResetParameters()
    {
        m_animator.SetBool("isMoving", false);
        m_animator.SetBool("isFlinching", false);
        m_animator.SetBool("isAttacking", false);
    }
}

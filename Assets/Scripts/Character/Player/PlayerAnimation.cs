using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void IsJumping(bool condition)
    {
        m_animator.SetBool("isJumping", condition);
    }

    public void IsDoubleJumping(bool condition)
    {
        m_animator.SetBool("isDoubleJumping", condition);
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

    public void ResetParameters()
    {
        m_animator.SetBool("isRunning", false);
        m_animator.SetBool("isJumping", false);
        m_animator.SetBool("isDoubleJumping", false);
        m_animator.SetBool("isFlinching", false);
    }
}

using UnityEngine;

public class CharacterState : MonoBehaviour
{
    protected State m_playerState;
    protected GroundnessState m_groundnessState;

    public enum State
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Attacking,
        Flinching,
        Dead
    }
    public enum GroundnessState
    {
        OnAir,
        OnGround,
        OnwWater
    }
    public void ChangeState(State state)
    {
        m_playerState = state;
    }

    public State CurrentState()
    {
        return m_playerState;
    }
    public void ChangeGroundnessState(GroundnessState state)
    {
        m_groundnessState = state;
    }

    public GroundnessState GetGroundnessState()
    {
        return m_groundnessState;
    }
}

using UnityEngine;

public class ThePrimetimeDramaAI : EnemyAI
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (m_target != null)
        {
            switch (m_state.CurrentState())
            {
                case CharacterState.State.Idle:
                    break;

                case CharacterState.State.Walking:
                    Debug.Log("Player is walking slowly.");
                    break;

                case CharacterState.State.Attacking:

                    break;

                case CharacterState.State.Flinching:
                    Debug.Log("Player is flinching!");
                    break;

                case CharacterState.State.Dead:
                    Debug.Log("Game Over. Player is dead.");
                    break;

                default:
                    Debug.LogWarning("Unknown player state.");
                    break;
            }
        }
    }
}

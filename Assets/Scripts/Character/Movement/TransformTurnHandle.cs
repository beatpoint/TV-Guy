using TVGuy.Gameplay.Characters;
using UnityEngine;

namespace TVGuy.Gameplay.Characters
{
    public class TransformTurnHandle : SimpleTurnHandle
    {
        public override void Execute()
        {
            TurnCharacter();
            if (m_maintainScaleValue == true)
            {
                var shouldBeNegative = m_character.facing == HorizontalDirection.Left;
                var currentScale = m_character.transform.localScale;
                if (shouldBeNegative && currentScale.x > 0)
                {
                    currentScale.x = currentScale.x * -1;
                }
                else if (currentScale.x < 0)
                {
                    currentScale.x = Mathf.Abs(currentScale.x);
                }
                m_character.transform.localScale = currentScale;
            }
            else
            {
                var currentScale = m_character.facing == HorizontalDirection.Left ? new Vector3(-1, 1, 1) : Vector3.one;
                m_character.transform.localScale = currentScale;
            }


            CallTurnDone(new FacingEventArgs(m_character.facing));
        }
    }
}
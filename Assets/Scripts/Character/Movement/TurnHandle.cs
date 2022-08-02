using TVGuy.Gameplay;
using TVGuy.Gameplay.Characters;
using TVGuy.Event;
using UnityEngine;

namespace TVGuy.Gameplay.Characters
{
    public abstract class TurnHandle : MonoBehaviour
    {
        [SerializeField]
        protected Character m_character;
        [SerializeField]
        protected bool m_maintainScaleValue;
        public event EventAction<FacingEventArgs> TurnDone;

        protected void TurnCharacter()
        {
            m_character.SetFacing(m_character.facing == HorizontalDirection.Left ? HorizontalDirection.Right : HorizontalDirection.Left);
        }

        protected Vector3 GetFacingScale(HorizontalDirection horizontalDirection)
        {
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
                return currentScale;
            }
            else
            {
                var currentScale = m_character.facing == HorizontalDirection.Left ? new Vector3(-1, 1, 1) : Vector3.one;
                return currentScale;
            }



        }

        protected void CallTurnDone(FacingEventArgs eventArgs) => TurnDone?.Invoke(this, eventArgs);



#if UNITY_EDITOR
        public void InitializeField(Character character)
        {
            m_character = character;
        }
#endif
    }
}
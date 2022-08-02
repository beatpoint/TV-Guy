using TVGuy.Event;

namespace TVGuy.Gameplay.Characters
{
    public struct FacingEventArgs : IEventActionArgs
    {
        public FacingEventArgs(HorizontalDirection currentFacingDirection) : this()
        {
            this.currentFacingDirection = currentFacingDirection;
        }

        public HorizontalDirection currentFacingDirection { get; }

    }

    public interface ITurningCharacter
    {
        event EventAction<FacingEventArgs> CharacterTurn;
    }
}

using TVGuy.Event;

namespace TVGuy.Gameplay.Combat
{
    public interface IAttacker
    {
        IAttacker parentAttacker { get; }
        IAttacker rootParentAttacker { get; }

        event EventAction<CombatConclusionEventArgs> TargetDamaged;

        void SetParentAttacker(IAttacker damageDealer);
        void SetRootParentAttacker(IAttacker damageDealer);

    }
}
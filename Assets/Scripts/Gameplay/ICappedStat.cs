using TVGuy.Event;

namespace TVGuy.Gameplay
{

    public interface ICappedStat : IMaxStat
    {
        int currentValue { get; }
        void AddCurrentValue(int value);
        void ReduceCurrentValue(int value);
        void ResetValueToMax();
        event EventAction<StatInfoEventArgs> ValueChanged;
    }
}
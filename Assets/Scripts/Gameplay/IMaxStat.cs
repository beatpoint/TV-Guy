using TVGuy.Event;

namespace TVGuy.Gameplay
{
    public interface IMaxStat
    {
        int maxValue { get; }
        void SetMaxValue(int value);
        event EventAction<StatInfoEventArgs> MaxValueChanged;
    }
}
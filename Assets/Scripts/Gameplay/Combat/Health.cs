
using TVGuy.Event;
using TVGuy.Gameplay;
using System;
using UnityEngine;

namespace TVGuy.Gameplay.Combat
{

    [Serializable]
    public abstract class Health : MonoBehaviour, ICappedStat, ICappedStatInfo
    {
        public event EventAction<EventActionArgs> Death;
        public event EventAction<StatInfoEventArgs> MaxValueChanged;
        public event EventAction<StatInfoEventArgs> ValueChanged;

        [SerializeField, Range(0, 100)]
        protected int m_currentHealth;
        //[ShowInInspector, ReadOnly, ProgressBar(0f, 1f)]
        protected float m_percentHealth;

        public bool isEmpty => m_currentHealth <= 0f;
        public bool isFull => m_currentHealth >= maxValue;
        public int currentValue => m_currentHealth;
        public abstract int maxValue { get; }

        public virtual void SetMaxValue(int value)
        {
            MaxValueChanged?.Invoke(this, new StatInfoEventArgs(m_currentHealth, maxValue));
        }

        public void SetHealthPercentage(float percent)
        {
            m_percentHealth = percent;
            m_currentHealth = Mathf.CeilToInt(m_percentHealth * maxValue);
        }

        public virtual void ReduceCurrentValue(int damage)
        {
            m_currentHealth -= damage;
            if (m_currentHealth <= 0)
            {
                m_currentHealth = 0;
                Death?.Invoke(this, EventActionArgs.Empty);
            }
            ValueChanged?.Invoke(this, new StatInfoEventArgs(m_currentHealth, maxValue));
            m_percentHealth = (float)m_currentHealth / maxValue;
        }

        public void AddCurrentValue(int value)
        {
            m_currentHealth += value;
            if (m_currentHealth > maxValue)
            {
                m_currentHealth = maxValue;
            }
            ValueChanged?.Invoke(this, new StatInfoEventArgs(m_currentHealth, maxValue));
            m_percentHealth = (float)m_currentHealth / maxValue;
        }

        public void ResetValueToMax()
        {
            m_currentHealth = maxValue;
            m_percentHealth = 1f;
            ValueChanged?.Invoke(this, new StatInfoEventArgs(m_currentHealth, maxValue));
        }

        public void Empty()
        {
            m_currentHealth = 0;
            m_percentHealth = 0f;
            ValueChanged?.Invoke(this, new StatInfoEventArgs(m_currentHealth, maxValue));
        }

#if UNITY_EDITOR
        protected void SendValueEvent()
        {
            m_percentHealth = (float)m_currentHealth / maxValue;
            ValueChanged?.Invoke(this, new StatInfoEventArgs(m_currentHealth, maxValue));
        }
        protected void SendMaxValue()
        {
            m_percentHealth = (float)m_currentHealth / maxValue;
            MaxValueChanged?.Invoke(this, new StatInfoEventArgs(m_currentHealth, maxValue));
            ValueChanged?.Invoke(this, new StatInfoEventArgs(m_currentHealth, maxValue));
        }
#endif
    }
}
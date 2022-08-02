using System.Collections;
using TVGuy.Event;
using UnityEngine;

namespace TVGuy.Gameplay
{
    public class CooldownTimer : MonoBehaviour
    {
        [SerializeField]
        private float m_cooldownTime;
        public float cooldownTime => m_cooldownTime;

        private bool m_inCooldown;
        public bool inCooldown => m_inCooldown;
        private Coroutine m_cooldownCoroutine;

        public event EventAction<EventActionArgs> CooldownStart;
        public event EventAction<EventActionArgs> CooldownEnd;

        public void StartCooldown()
        {
            if (m_cooldownCoroutine != null)
            {
                StopCoroutine(m_cooldownCoroutine);
                m_cooldownCoroutine = null;
            }
            m_cooldownCoroutine = StartCoroutine(CooldownRoutine());
        }

        private IEnumerator CooldownRoutine()
        {
            CooldownStart?.Invoke(this, new EventActionArgs());
            m_inCooldown = true;
            yield return new WaitForSeconds(m_cooldownTime);
            m_inCooldown = false;
            CooldownEnd?.Invoke(this, new EventActionArgs());
            yield return null;
        }
    }
}

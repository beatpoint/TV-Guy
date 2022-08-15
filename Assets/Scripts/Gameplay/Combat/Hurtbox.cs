using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TVGuy.Gameplay.Characters.Combat
{
    public class Hurtbox : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 10f)]
        private float m_hurboxDuration = 0.1f;
        [SerializeField]
        private float m_delayStart;

        private Collider2D m_hurtboxCollider;

        private void Awake()
        {
            m_hurtboxCollider = GetComponent<Collider2D>();
            m_hurtboxCollider.enabled = false;
        }

        public void ActivatedHurtbox()
        {
            StartCoroutine(HurtboxRoutine());
        }

        private IEnumerator HurtboxRoutine()
        {
            yield return new WaitForSeconds(m_delayStart);
            m_hurtboxCollider.enabled = true;
            yield return new WaitForSeconds(m_hurboxDuration);
            m_hurtboxCollider.enabled = false;
            yield return null;
        }
    }
}

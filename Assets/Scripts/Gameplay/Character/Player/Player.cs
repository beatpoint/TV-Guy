using System;
//using TVGuy.Gameplay.Characters.Players.Modules;
//using TVGuy.Gameplay.Characters.Players.State;
using TVGuy.Gameplay.Combat;
using TVGuy.Gameplay.Combat.StatusAilment;
//using TVGuy.Gameplay.Inventories;
//using TVGuy.Serialization;
//using Doozy.Engine;
using TVGuy.Event;
using TVGuy.Gameplay.Characters.Players;
using UnityEngine;
//using TVGuy.Gameplay.Characters.Players.Behaviour;
//using TVGuy.Gameplay.SoulSkills;
//using TVGuy.Gameplay.Items;

namespace TVGuy.Gameplay.Characters.Players
{
    public interface IPlayer
    {
        event EventAction<EventActionArgs> OnDeath;
        //[SerializeField]
        //Modules.CharacterState state { get; }
        //IPlayerStats stats { get; }
        Health health { get; }
        //Magic magic { get; }
        Health armor { get; }
        IHealable healableModule { get; }
        IDamageable damageableModule { get; }
        IAttacker attackModule { get; }
        ExtendedAttackResistance attackResistance { get; }
        StatusEffectResistance statusResistance { get; }
        StatusEffectReciever statusEffectReciever { get; }
        Character character { get; }

        int GetInstanceID();
    }

    [AddComponentMenu("DChild/Gameplay/Player/Player")]
    public class Player : MonoBehaviour, IPlayer
    {
        //[SerializeField]
        //private PlayerStats m_stats;
        //[SerializeField]
        //private PlayerWeapon m_weapon;
        [SerializeField]
        private ExtendedAttackResistance m_attackResistance;
        [SerializeField]
        private StatusEffectResistance m_statusResistance;
        //[SerializeField]
        //private PlayerModifierHandle m_modifiers;
        //[SerializeField]
        //private PlayerModuleActivator m_behaviourModule;
        //[SerializeField]
        //private PlayerSkills m_skills;
        //[SerializeField]
        //private PlayerSoulSkillHandle m_soulSkills;
        //[SerializeField]
        //private PlayerCharacterController m_controller;
        //[SerializeField]
        //private PlayerIntroControlsController m_introController;
        //[SerializeField]
        //private PlayerInventory m_inventory;
        //[SerializeField]
        //private ItemEffectHandle m_itemEffectHandle;

        [SerializeField]
        private Character m_controlledCharacter;
        [SerializeField]
        private Damageable m_damageable;
        [SerializeField]
        private Attacker m_attacker;
        [SerializeField]
        private Health m_armor;
        [SerializeField]
        private StatusEffectReciever m_statusEffectReciever;

        public event EventAction<EventActionArgs> OnDeath;

        //public IPlayerStats stats => m_stats;

        //public Modules.CharacterState state => m_state;
        public Health health => m_damageable.health;
        public Health armor => m_armor;
        public IHealable healableModule => m_damageable;
        public IDamageable damageableModule => m_damageable;
        public IAttacker attackModule => m_attacker;

        public ExtendedAttackResistance attackResistance => m_attackResistance;
        public StatusEffectReciever statusEffectReciever => m_statusEffectReciever;

        public StatusEffectResistance statusResistance => m_statusResistance;
        public Character character => m_controlledCharacter;

        //public Character character => m_controlledCharacter;alizer.LoadData(data);

        public void Initialize()
        {
            m_attackResistance.Initialize();
            m_statusResistance.Initialize();
            //m_modifiers.Initialize();
        }

        //public void SetPosition(Vector2 position)
        //{
        //    m_controlledCharacter.transform.position = position;
        //}

        private void Awake()
        {
            //var controlledObject = m_controlledCharacter.gameObject.AddComponent<PlayerControlledObject>();
            //controlledObject.SetOwner(this);
            m_damageable.Destroyed += OnDestroyed;
        }

        private void OnDestroyed(object sender, EventActionArgs eventArgs)
        {
            OnDeath?.Invoke(this, eventArgs);
            m_damageable.SetHitboxActive(false);
        }

        public void Revitilize()
        {
            m_statusEffectReciever.RemoveAllActiveStatusEffects();
            healableModule.Heal(9999999);
            health.ResetValueToMax();

            //Stop Coroutines for items
        }

        //public void Reset()
        //{
        //    m_controller.Enable();
        //}

#if UNITY_EDITOR
        public void Initialize(GameObject character)
        {
            m_controlledCharacter = character.GetComponentInChildren<Character>();
            //m_state = character.GetComponentInChildren<Modules.CharacterState>();
            m_damageable = character.GetComponentInChildren<Damageable>();
            m_attacker = character.GetComponentInChildren<Attacker>();
        }
#endif
    }
}
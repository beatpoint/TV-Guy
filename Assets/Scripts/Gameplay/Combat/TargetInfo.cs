using TVGuy.Gameplay.Characters;
using TVGuy.Gameplay.Characters.Players;
using TVGuy.Gameplay.Combat.StatusAilment;
//using TVGuy.Gameplay.Environment;
//using TVGuy.Gameplay.VFX;
using UnityEngine;

namespace TVGuy.Gameplay.Combat
{
    public class TargetInfo
    {
        public IDamageable instance { get; private set; }
        public BodyDefense bodyDefense { get; private set; }
        //public FXSpawnConfigurationInfo damageFXInfo { get; private set; }
        public bool canBlockDamage { get; private set; }
        public Collider2D hitCollider { get; private set; }


        public bool isCharacter { get; private set; }
        public bool hasBestiaryData { get; private set; }
        public int bestiaryID { get; private set; }
        public HorizontalDirection facing { get; private set; }
        public IFlinch flinchHandler { get; private set; }
        public bool isPlayer { get; private set; }

        private IPlayer m_owner;
        public IPlayer owner => m_owner;
        public StatusEffectReciever statusEffectReciever { get; private set; }

        public void Initialize(IDamageable target, bool canBlockDamage, BodyDefense bodyDefense, Collider2D hitCollider, Character character = null, IFlinch flinchHandler = null)
        {
            InitializeEssentials(target, canBlockDamage, bodyDefense, hitCollider);
            isCharacter = character;
            if (isCharacter)
            {
                facing = character.facing;
                statusEffectReciever = character.GetComponent<StatusEffectReciever>();
                isPlayer = GameplaySystem.playerManager.IsPartOfPlayer(character.gameObject, out m_owner);
            }


            this.flinchHandler = flinchHandler;
        }

        public void Initialize(IDamageable target, bool canBlockDamage, BodyDefense bodyDefense, Collider2D hitCollider)
        {
            InitializeEssentials(target, canBlockDamage, bodyDefense, hitCollider);

            isCharacter = false;
            isPlayer = false;
            statusEffectReciever = null;
            m_owner = null;
            hasBestiaryData = false;
            flinchHandler = null;
        }

        public void Initialize(Hitbox hitbox, Collider2D hitCollider, Character character = null, IFlinch flinchHandler = null)
        {
            InitializeEssentials(hitbox, hitCollider);
            isCharacter = character;
            if (isCharacter)
            {
                facing = character.facing;
                statusEffectReciever = character.GetComponent<StatusEffectReciever>();
                isPlayer = GameplaySystem.playerManager.IsPartOfPlayer(character.gameObject, out m_owner);
                hasBestiaryData = character.hasID;
            }

            this.flinchHandler = flinchHandler;
        }

        public void Initialize(Hitbox hitbox, Collider2D hitCollider)
        {
            InitializeEssentials(hitbox, hitCollider);

            isCharacter = false;
            isPlayer = false;
            statusEffectReciever = null;
            m_owner = null;
            hasBestiaryData = false;
            flinchHandler = null;

        }

        private void InitializeEssentials(Hitbox hitbox, Collider2D hitCollider)
        {
            InitializeEssentials(hitbox.damageable, hitbox.canBlockDamage, hitbox.defense, hitCollider);
        }

        private void InitializeEssentials(IDamageable target, bool canBlockDamage, BodyDefense bodyDefense, Collider2D hitCollider)
        {
            this.instance = target;
            this.canBlockDamage = canBlockDamage;
            this.bodyDefense = bodyDefense;
            this.hitCollider = hitCollider;
        }
    }
}
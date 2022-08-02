using System;
using System.Collections;
using System.Collections.Generic;
using TVGuy.Gameplay.Characters.Players;
using TVGuy.Gameplay.Combat;
using TVGuy;
using TVGuy.Event;
using UnityEngine;

namespace TVGuy.Gameplay.Systems
{
    public interface IPlayerManager
    {
        Player player { get; }

        bool IsPartOfPlayer(GameObject gameObject);
        bool IsPartOfPlayer(GameObject gameObject, out IPlayer player);

        void StopCharacterControlOverride();
        void DisableControls();
        void EnableControls();
        void EnableIntroControls();
        void DisableIntroControls();
    }
    public class PlayerManager : MonoBehaviour, /*IGameplaySystemModule, IGameplayInitializable,*/ IPlayerManager
    {
        [SerializeField]
        private Player m_player;
        public Player player => m_player;

        public void DisableControls()
        {
            throw new NotImplementedException();
        }

        public void DisableIntroControls()
        {
            throw new NotImplementedException();
        }

        public void EnableControls()
        {
            throw new NotImplementedException();
        }

        public void EnableIntroControls()
        {
            throw new NotImplementedException();
        }

        public bool IsPartOfPlayer(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public bool IsPartOfPlayer(GameObject gameObject, out IPlayer player)
        {
            throw new NotImplementedException();
        }

        public void StopCharacterControlOverride()
        {
            throw new NotImplementedException();
        }
    }
}
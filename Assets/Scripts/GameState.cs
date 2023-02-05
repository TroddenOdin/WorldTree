using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    public class GameState : MonoBehaviour
    {
        public static GameState instance { get; private set; }
        private int _playerCount;
        public GamePlayState currentState { get; private set; }

        private void Start()
        {
            if(instance == null) instance = this;

            if (transform.parent != null)
                transform.parent = null;

            _playerCount = 0;
            currentState = GamePlayState.WaitingForPlayer;
        }

        public int PlayerConnect()
        {
            ++_playerCount;
            Debug.Log(_playerCount);

            return _playerCount;
        }

        public int PlayerDisconnect()
        {
            --_playerCount;
            Debug.Log(_playerCount);

            return _playerCount;
        }
    }
}

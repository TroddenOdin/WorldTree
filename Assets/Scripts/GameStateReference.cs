using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    public class GameStateReference : MonoBehaviour
    {
        private int _playerNum;
        private GameState _gameState;
        public GameState state
        {
            get
            {
                if(_gameState == null)
                    _gameState = GameState.instance;
                return _gameState;
            }
        }

        public void PlayerConnect()
        {
            state.PlayerConnect();
        }

        public void PlayerDisconnect()
        {
            state.PlayerDisconnect();
        }

        public void PlayerSelectFaction()
        {
        }
    }
}

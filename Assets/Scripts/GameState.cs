using Coherence.Runtime;
using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    public class GameState : MonoBehaviour
    {
        public static GameState instance { get; private set; }
        [Sync("PlayerCount")]
        public int playerCount;
        public GamePlayState currentState { get; private set; }
        [Sync("Faction")]
        public int _internalFaction;
        public Faction selectedFaction => (Faction)_internalFaction;

        private void Start()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            if (transform.parent != null)
                transform.parent = null;

            playerCount = 0;
            currentState = GamePlayState.WaitingForPlayer;
            _internalFaction = (int)Faction.Neutral;
        }

        public void PlayerConnect()
        {
            ++playerCount;
            Debug.Log(playerCount);
        }

        public void PlayerDisconnect()
        {
            --playerCount;
            Debug.Log(playerCount);
        }

        public void PlayerSelectFaction(Faction faction)
        {
            if(selectedFaction == Faction.Neutral)
                _internalFaction = (int)faction;
        }
    }
}

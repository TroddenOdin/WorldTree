using Coherence.Runtime;
using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private Player naturePlayer;

        [SerializeField] private GameObject loseScreen;
        [SerializeField] private GameObject winScreen;

        bool gameFinished = false;

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

        private void Update()
        {
            if(naturePlayer && !gameFinished)
            {
                if(naturePlayer.currentHealth <= 0f)
                {
                    loseScreen.SetActive(true);
                    gameFinished = true;
                }

                if(ManaWell.manaWells.Where(well => well.allegiance == Faction.Nature).Count() >= ManaWell.manaWells.Count - 1)
                {
                    winScreen.SetActive(true);
                    gameFinished = true;
                }
            }
        }

        public void HandleNewPlayer(Player player)
        {
            if(player.faction == Faction.Nature)
            {
                naturePlayer = player;
            }
        }

        public void PlayerConnect()
        {
            ++playerCount;
        }

        public void PlayerDisconnect()
        {
            --playerCount;
        }

        public void PlayerSelectFaction(Faction faction)
        {
            if(selectedFaction == Faction.Neutral)
                _internalFaction = (int)faction;
        }
    }
}

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
        [Sync("PlayerCount"), HideInInspector]
        public int playerCount;
        public GamePlayState currentState { get; private set; }
        [Sync("Faction"), HideInInspector]
        public int _internalFaction;
        public Faction selectedFaction => (Faction)_internalFaction;

        private Player _naturePlayer;
        [SerializeField]
        private Unit _worldTree;

        [SerializeField]
        private GameObject _gameOverScreen;
        [SerializeField] 
        private GameObject _loseText;
        [SerializeField] 
        private GameObject _winText;

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

            _worldTree.OnDamage.AddListener(UpdateNaturePlayerHealth);
        }

        private void Update()
        {
            if(_naturePlayer && !gameFinished)
            {
                if(_naturePlayer.currentHealth <= 0f)
                {
                    GameObject.Find("WorldTreeCanvas")?.SetActive(false);
                    GameObject.Find("VikingCanvas")?.SetActive(false);
                    _gameOverScreen.SetActive(true);
                    _loseText.SetActive(true);
                    gameFinished = true;
                }

                if(ManaWell.manaWells.Where(well => well.allegiance == Faction.Nature).Count() >= ManaWell.manaWells.Count - 1)
                {
                    GameObject.Find("WorldTreeCanvas")?.SetActive(false);
                    GameObject.Find("VikingCanvas")?.SetActive(false);
                    _gameOverScreen.SetActive(true);
                    _winText.SetActive(true);
                    gameFinished = true;
                }
            }
        }

        public void UpdateNaturePlayerHealth(Unit unit)
        {
            if (!_naturePlayer) return;

            _naturePlayer.currentHealth = unit.currentHealth / unit.stats.health * _naturePlayer.maxHealth;
        }

        public void HandleNewPlayer(Player player)
        {
            if(player.faction == Faction.Nature)
            {
                _naturePlayer = player;
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
            if (faction == Faction.Nature)
                _naturePlayer = GameObject.FindObjectsOfType<Player>().Where(player => player.faction == Faction.Nature).First();
        }
    }
}

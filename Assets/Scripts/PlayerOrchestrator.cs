using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WorldTree
{
    [RequireComponent(typeof(Player))]
    public class PlayerOrchestrator : MonoBehaviour
    {
        [SerializeField]
        private Faction _faction;
        public Faction faction => _faction;

        [SerializeField]
        private UnitsSelection _selections;
        [SerializeField]
        private UnitMovement _movement;
        [SerializeField]
        private CameraController _cameraController;
        private Player _player;

        public UnityEvent<Player> OnCreate;


        private void Start()
        {
            _selections.gameObject.SetActive(false);
            _movement.gameObject.SetActive(false);
            _cameraController.enabled = false;
        }

        public void EnablePlayerScripts(Faction faction)
        {
            _faction = faction;
            Globals.FACTION = _faction;
            _selections.gameObject.SetActive(true);
            _movement.gameObject.SetActive(true);
            _cameraController.enabled = true;
            _player = GetComponent<Player>();
            _player.SetFaction(_faction);

            OnCreate.Invoke(_player);
        }
    }
}

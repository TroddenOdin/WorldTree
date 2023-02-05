using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace WorldTree
{
    public class Player : MonoBehaviour
    {
        public PlayerUi playerUi;

        public float currentHealth;
        public float maxHealth = 100;
        public float minHealth = 0;

        public float currentMana;
        public float maxMana = 100;
        public float minMana = 0;

        private Faction _faction;
        public Faction faction => _faction;

        // Arbitrary constants added to hasten script writing used here
        public float manaGain =>
            5 * ((_faction == Faction.Nature ? 5 : 2) + ManaWell.manaWells.Where(well => well.allegiance == _faction).Count());

        // Start is called before the first frame update
        private void Start()
        {
            playerUi.SetMaxHealth();
            playerUi.SetMaxMana();

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Backspace)) currentMana -= 10;

            currentMana += Time.deltaTime * manaGain;

            if (currentMana > maxMana) currentMana = maxMana;
        }

        public void SetFaction(Faction faction)
        {
            _faction = faction;
        }
    }
}

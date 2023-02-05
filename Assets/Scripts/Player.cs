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

       //public int manaUsageAmount;

        private Faction _faction;
        public Faction faction => _faction;

        public Button treeUnitButton1;
        public Button treeUnitButton2;
        public Button treeUnitButton3;
        public Button treeAbilityButton1;
        public Button treeAbilityButton2;

        public Button vikingUnitButton1;
        public Button vikingUnitButton2;
        public Button vikingUnitButton3;
        public Button vikingAbilityButton1;
        public Button vikingAbilityButton2;


        public int[] treeManaUsageAmount;
        public int[] vikingManaUsageAmount;


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

        public void TreeUnitButton1()
        {

            currentMana = currentMana -= treeManaUsageAmount[0];
            playerUi.SetMana();

        }
        public void TreeUnitButton2()
        {
            currentMana = currentMana -= treeManaUsageAmount[1];
            playerUi.SetMana();
        }
        public void TreeUnitButton3()
        {
            currentMana = currentMana -= treeManaUsageAmount[2];
            playerUi.SetMana();
        }
        public void TreeAbilityButton1()
        {
            currentMana = currentMana -= treeManaUsageAmount[3];
            playerUi.SetMana();
        }
        public void TreeAbilityButton2()
        {
            currentMana = currentMana -= treeManaUsageAmount[4];
            playerUi.SetMana();
        }

        public void VikingUnitButton1()
        {
            currentMana = currentMana -= vikingManaUsageAmount[0];
            playerUi.SetMana();
        }
        public void VikingUnitButton2()
        {
            currentMana = currentMana -= vikingManaUsageAmount[1];
            playerUi.SetMana();
        }
        public void VikingUnitButton3()
        {
            currentMana = currentMana -= vikingManaUsageAmount[2];
            playerUi.SetMana();
        }
        public void VikingAbilityButton1()
        {
            currentMana = currentMana -= vikingManaUsageAmount[3];
            playerUi.SetMana();
        }
        public void VikingAbilityButton2()
        {
            currentMana = currentMana -= vikingManaUsageAmount[4];
            playerUi.SetMana();
        }
    }
}

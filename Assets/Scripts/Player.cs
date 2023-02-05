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


        public List<int> treeAbilityMana = new(2) { 0, 0 };
        public List<int> vikingAbilityMana = new(2) { 0, 0 };

        [SerializeField]
        private List<GameObject> _treeUnitPrefabs = new(3) { null, null, null };
        [SerializeField]
        private List<GameObject> _vikingUnitPrefabs = new(3) { null, null, null };


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
            currentMana += Time.deltaTime * manaGain;

            if (currentMana > maxMana) currentMana = maxMana;
            else if (currentMana < 0) currentMana = 0;

            if (currentHealth > maxHealth) currentHealth = maxHealth;

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if(_faction == Faction.Nature)
                {
                    TreeUnitButton1();
                }
                else
                {
                    VikingUnitButton1();
                }
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                if(_faction == Faction.Nature)
                {
                    TreeUnitButton2();
                }
                else
                {
                    VikingUnitButton2();
                }
            }
        }

        public void SetFaction(Faction faction)
        {
            _faction = faction;
        }

        public void TreeUnitButton1()
        {
            if (currentMana - _treeUnitPrefabs[0].GetComponent<Unit>().stats.cost < 0) return;

            Instantiate(_treeUnitPrefabs[0]);
            currentMana -= _treeUnitPrefabs[0].GetComponent<Unit>().stats.cost;
            playerUi.SetMana();

        }
        public void TreeUnitButton2()
        {
            if (currentMana - _treeUnitPrefabs[1].GetComponent<Unit>().stats.cost < 0) return;

            Instantiate(_treeUnitPrefabs[1]);
            currentMana -= _treeUnitPrefabs[1].GetComponent<Unit>().stats.cost;
            playerUi.SetMana();
        }
        public void TreeUnitButton3()
        {
            if (currentMana - _treeUnitPrefabs[2].GetComponent<Unit>().stats.cost < 0) return;

            Instantiate(_treeUnitPrefabs[2]);
            currentMana -= _treeUnitPrefabs[2].GetComponent<Unit>().stats.cost;
            playerUi.SetMana();
        }
        public void TreeAbilityButton1()
        {
            currentMana -= treeAbilityMana[0];
            playerUi.SetMana();
        }
        public void TreeAbilityButton2()
        {
            currentMana -= treeAbilityMana[1];
            playerUi.SetMana();
        }

        public void VikingUnitButton1()
        {
            if (currentMana - _vikingUnitPrefabs[0].GetComponent<Unit>().stats.cost < 0) return;

            Instantiate(_vikingUnitPrefabs[0]);
            currentMana -= _vikingUnitPrefabs[0].GetComponent<Unit>().stats.cost;
            playerUi.SetMana();
        }
        public void VikingUnitButton2()
        {
            if (currentMana - _vikingUnitPrefabs[1].GetComponent<Unit>().stats.cost < 0) return;

            Instantiate(_vikingUnitPrefabs[1]);
            currentMana -= _vikingUnitPrefabs[1].GetComponent<Unit>().stats.cost;
            playerUi.SetMana();
        }
        public void VikingUnitButton3()
        {
            if (currentMana - _vikingUnitPrefabs[2].GetComponent<Unit>().stats.cost < 0) return;

            Instantiate(_vikingUnitPrefabs[2]);
            currentMana -= _vikingUnitPrefabs[2].GetComponent<Unit>().stats.cost;
            playerUi.SetMana();
        }
        public void VikingAbilityButton1()
        {
            currentMana -= vikingAbilityMana[0];
            playerUi.SetMana();
        }
        public void VikingAbilityButton2()
        {
            currentMana -= vikingAbilityMana[1];
            playerUi.SetMana();
        }

        private void OnValidate()
        {
            if(vikingAbilityMana.Count != 2)
            {
                int dif = vikingAbilityMana.Count - 2;
                bool adding = dif < 0;
                dif = Mathf.Abs(dif);
                for(int i = 0; i < dif; ++i)
                {
                    if (adding)
                        vikingAbilityMana.Add(0);
                    else
                        vikingAbilityMana.RemoveAt(vikingAbilityMana.Count - 1);
                }
            }
            if(treeAbilityMana.Count != 2)
            {
                int dif = treeAbilityMana.Count - 2;
                bool adding = dif < 0;
                dif = Mathf.Abs(dif);
                for(int i = 0; i < dif; ++i)
                {
                    if (adding)
                        treeAbilityMana.Add(0);
                    else
                        treeAbilityMana.RemoveAt(treeAbilityMana.Count - 1);
                }
            }

            if(_treeUnitPrefabs.Count != 3)
            {
                int dif = _treeUnitPrefabs.Count - 3;
                bool adding = dif < 0;
                dif = Mathf.Abs(dif);
                for (int i = 0; i < dif; ++i)
                {
                    if (adding)
                        _treeUnitPrefabs.Add(null);
                    else
                        _treeUnitPrefabs.RemoveAt(_treeUnitPrefabs.Count - 1);
                }
            }
            if (_vikingUnitPrefabs.Count != 3)
            {
                int dif = _vikingUnitPrefabs.Count - 3;
                bool adding = dif < 0;
                dif = Mathf.Abs(dif);
                for (int i = 0; i < dif; ++i)
                {
                    if (adding)
                        _vikingUnitPrefabs.Add(null);
                    else
                        _vikingUnitPrefabs.RemoveAt(_vikingUnitPrefabs.Count - 1);
                }
            }
        }
    }
}

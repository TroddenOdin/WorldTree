using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WorldTree.Core
{


    public class MiningTaskManager : MonoBehaviour
    {


        bool mining = false;
        bool canMine = true;
        public float timeToMine = 2;

        ManaInventory manaInv;
        UnitMovement unitMovt;
        public GameObject targetMine;


        // Start is called before the first frame update
        void Start()
        {
            manaInv = GetComponent<ManaInventory>();
            unitMovt = GetComponent<UnitMovement>();
        }

        // Update is called once per frame
        void Update()
        {
            if (mining)
            {
                Mining();
            }
        }

        void Mining()
        {

            if (manaInv.itemsinInventory < manaInv.maxItemsinInventory)
            {

                //trigger of mine/mana well/resource
                //unitMovt.target = targetMine.transform.position;
                if (Vector3.Distance(targetMine.transform.position, transform.position) < 2.1)
                {
                    if (canMine)
                    {
                        StartCoroutine(Mine());

                    }
                }
            }
            else
            {

            }
           
        }


        IEnumerator Mine()
        {
            canMine = false;
            yield return new WaitForSeconds(timeToMine);
            manaInv.itemsinInventory++;
            manaInv.rType = resourceTypes.Mana;
            canMine = true;
        }
    }

}

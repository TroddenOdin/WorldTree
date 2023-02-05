using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WorldTree.Core
{
    public class GathererAI : MonoBehaviour
    {
       private enum State
        {
            Idle,
            MovingToMine,
            Mining,
            MovingToStorage
        }

        private IMine unit;
        private State state;
        private Transform resourceNodeTransform;
        private Transform storageTransform;
        private int manaInventoryAmount;

        private void Awake()
        {
            unit = gameObject.GetComponent<IMine>();
            state = State.Idle;

           /* unit.MoveTo(manaWellTransform.position, 10f, () =>
            {
                unit.PlayAnimationMine(manaWellTransform.position, () =>
                {
                    unit.MoveTo(manaStorage, 5f, null);
                });
            });
            */
         }
        private void Update()
        {
            switch (state)
            {
                case State.Idle:
                    resourceNodeTransform = ManaHandler.GetResourceNode_Static();
                    state = State.MovingToMine;
                    break;
                 case State.MovingToMine:
                    if (unit.IsIdle()){
                        unit.MoveTo(resourceNodeTransform.position, 10f, () =>
                        {
                            state = State.Mining;
                        });
                    }
                    break;
                case State.Mining:
                    if (unit.IsIdle())
                    { if (manaInventoryAmount > 0)
                        {
                            // move to storage
                            storageTransform = ManaHandler.GetStorage_Static();
                            state = State.MovingToStorage;
                        }
                        else
                        {
                            unit.PlayAnimationMine(resourceNodeTransform.position, () =>
                            {
                                manaInventoryAmount++;
                            });
                        }
                    }

                    break;
                case State.MovingToStorage:
                    if (unit.IsIdle())
                    {
                        unit.MoveTo(storageTransform.position, 10f, () =>
                        {
                            manaInventoryAmount = 0;
                            state = State.Idle;
                        });
                    }
                    break;


            }
        }

    }


        
    }


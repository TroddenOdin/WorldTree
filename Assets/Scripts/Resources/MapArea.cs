using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree.Core
{
    public class MapArea : MonoBehaviour
    {
        public event EventHandler OnCaptured;
        public event EventHandler OnPlayerEnter;
        public event EventHandler OnPlayerExit;

        public enum State
        {
            Neutral,
            Captured
        }

        private List<ManaWellArea> manaWellAreaList;
        private State state;
        private float progress;

        private void Awake()
        {
            manaWellAreaList = new List<ManaWellArea>();

            foreach (Transform child in transform)
            {
                ManaWellArea manaWellArea = child.GetComponent<ManaWellArea>();
                if(manaWellArea != null)
                {
                    manaWellAreaList.Add(manaWellArea);
                    manaWellArea.OnPlayerEnter += ManaWellArea_OnPlayerEnter;
                    manaWellArea.OnPlayerEnter += ManaWellArea_OnPlayerExit;
                }
            }

            state = State.Neutral;


        }
        private void ManaWellArea_OnPlayerExit(object sender, EventArgs e)
        {

            bool hasPlayerInside = false;
            foreach (ManaWellArea manaWellArea in manaWellAreaList)
            {
                if(manaWellArea.GetSkyTestList().Count > 0)
                {
                    hasPlayerInside = true;
                }
            }
            if (!hasPlayerInside)
            {
                OnPlayerExit?.Invoke(this, EventArgs.Empty);
            }
        }
        private void ManaWellArea_OnPlayerEnter(object sender, EventArgs e)
        {
            OnPlayerEnter?.Invoke(this, EventArgs.Empty);
        }


        private void Update() {

            switch (state)
            {
                case State.Neutral:
                    List<SkyTest> playerMapAreasInsideList = new List<SkyTest>();

                    int playerCountInsideManaWellArea = 0;
                    foreach (ManaWellArea manaWellArea in manaWellAreaList)
                    {
                        foreach (SkyTest skyTest in manaWellArea.GetSkyTestList())
                        {
                            if (!playerMapAreasInsideList.Contains(skyTest))
                            {
                                playerMapAreasInsideList.Add(skyTest);
                            }
                        }
                        playerCountInsideManaWellArea += manaWellArea.GetSkyTestList().Count;
                    }

                    float progressSpeed = 1f;
                    progress += playerCountInsideManaWellArea * progressSpeed * Time.deltaTime;


                    Debug.Log("playerCountInsideManaWellArea: " + playerCountInsideManaWellArea + "; progress: " + progress);

                    if(progress >= 5f)
                    {
                        state = State.Captured;
                        OnCaptured?.Invoke(this, EventArgs.Empty);
                        Debug.Log("Captured");
                    }
                    break;
                case State.Captured:
                    break;
            }
           
        }

        public float GetProgress()
        {
            return progress;
        }

    }
}

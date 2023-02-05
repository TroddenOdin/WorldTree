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
       
        public event EventHandler OnEnemyCaptured;
        public Faction faction;


        private List<ManaWellArea> manaWellAreaList;
       
        private float progress;
        private float enemyProgress;

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

        


        }
        private void ManaWellArea_OnPlayerExit(object sender, EventArgs e)
        {

            bool hasPlayerInside = false;
            foreach (ManaWellArea manaWellArea in manaWellAreaList)
            {
                if(manaWellArea.GetSkyTestList().Count > 0 || manaWellArea.GetSkyDefList().Count > 0)
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

            switch (faction)
            {
                case Faction.Nature:
                    List<SkyTest> playerMapAreasInsideList = new List<SkyTest>();
                    List<SkyTest> defMapAreasInsideList = new List<SkyTest>();

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

                    float enemyProgressSpeed = .10f;
                    enemyProgress += playerCountInsideManaWellArea * enemyProgressSpeed * Time.deltaTime;

                    int defCountInsideManaWellArea = 0;
                    foreach (ManaWellArea manaWellArea in manaWellAreaList)
                    {
                        foreach (SkyTest skyTest in manaWellArea.GetSkyDefList())
                        {
                            if (!defMapAreasInsideList.Contains(skyTest))
                            {
                                defMapAreasInsideList.Add(skyTest);
                            }
                        }
                        defCountInsideManaWellArea += manaWellArea.GetSkyDefList().Count;
                    }

                    float defendCapSpeed = .10f;
                    progress += defCountInsideManaWellArea * defendCapSpeed * Time.deltaTime;

                    Debug.Log("playerCountInsideManaWellArea: " + playerCountInsideManaWellArea + "; progress: " + progress);

                    if (enemyProgress >= 1f)
                    {
                        faction = Faction.Civilization;
                        progress = 0f;
                        OnEnemyCaptured?.Invoke(this, EventArgs.Empty);
                        Debug.Log("Captured");
                    }
                    if (progress >= 1f)
                    {
                        faction = Faction.Nature;
                        enemyProgress = 0f;
                        OnCaptured?.Invoke(this, EventArgs.Empty);
                        Debug.Log("Regained");
                    }
                    break;

                case Faction.Neutral:
                    List<SkyTest> nPlayerMapAreasInsideList = new List<SkyTest>();
                    List<SkyTest> nDefMapAreasInsideList = new List<SkyTest>();

                    int nPlayerCountInsideManaWellArea = 0;
                    foreach (ManaWellArea manaWellArea in manaWellAreaList)
                    {
                        foreach (SkyTest skyTest in manaWellArea.GetSkyTestList())
                        {
                            if (!nPlayerMapAreasInsideList.Contains(skyTest))
                            {
                                nPlayerMapAreasInsideList.Add(skyTest);
                            }
                        }
                        nPlayerCountInsideManaWellArea += manaWellArea.GetSkyTestList().Count;
                    }

                    float progressSpeed = .10f;
                    progress += nPlayerCountInsideManaWellArea * progressSpeed * Time.deltaTime;

                    int nDefCountInsideManaWellArea = 0;
                    foreach (ManaWellArea manaWellArea in manaWellAreaList)
                    {
                        foreach (SkyTest skyTest in manaWellArea.GetSkyDefList())
                        {
                            if (!nDefMapAreasInsideList.Contains(skyTest))
                            {
                                nDefMapAreasInsideList.Add(skyTest);
                            }
                        }
                        nDefCountInsideManaWellArea += manaWellArea.GetSkyDefList().Count;
                    }

                    float eCapSpeed = .10f;
                    enemyProgress += nDefCountInsideManaWellArea * eCapSpeed * Time.deltaTime;

                    Debug.Log("playerCountInsideManaWellArea: " + nDefCountInsideManaWellArea + "; progress: " + enemyProgress);

                    if(progress >= 1f)
                    {
                        faction = Faction.Nature;
                        enemyProgress = 0f;
                        OnCaptured?.Invoke(this, EventArgs.Empty);
                        Debug.Log("Captured");
                    }
                    if (enemyProgress >= 1f)
                    {
                        faction = Faction.Civilization;
                        progress = 0f;
                        OnEnemyCaptured?.Invoke(this, EventArgs.Empty);
                        Debug.Log("Captured");
                    }
                    break;
                case Faction.Civilization:
                    List<SkyTest> vPlayerMapAreasInsideList = new List<SkyTest>();
                    List<SkyTest> vDefMapAreasInsideList = new List<SkyTest>();

                    int vPlayerCountInsideManaWellArea = 0;
                    foreach (ManaWellArea manaWellArea in manaWellAreaList)
                    {
                        foreach (SkyTest skyTest in manaWellArea.GetSkyTestList())
                        {
                            if (!vPlayerMapAreasInsideList.Contains(skyTest))
                            {
                                vPlayerMapAreasInsideList.Add(skyTest);
                            }
                        }
                        vPlayerCountInsideManaWellArea += manaWellArea.GetSkyTestList().Count;
                    }

                    float vEnemyProgressSpeed = .10f;
                    enemyProgress += vPlayerCountInsideManaWellArea * vEnemyProgressSpeed * Time.deltaTime;

                    int vDefCountInsideManaWellArea = 0;
                    foreach (ManaWellArea manaWellArea in manaWellAreaList)
                    {
                        foreach (SkyTest skyTest in manaWellArea.GetSkyDefList())
                        {
                            if (!vDefMapAreasInsideList.Contains(skyTest))
                            {
                                vDefMapAreasInsideList.Add(skyTest);
                            }
                        }
                        vDefCountInsideManaWellArea += manaWellArea.GetSkyDefList().Count;
                    }

                    float vDefendCapSpeed = .10f;
                    progress += vDefCountInsideManaWellArea * vDefendCapSpeed * Time.deltaTime;

                    Debug.Log("playerCountInsideManaWellArea: " + vPlayerCountInsideManaWellArea + "; progress: " + progress);

                    if (enemyProgress >= 1f)
                    {
                        faction = Faction.Nature;
                        progress = 0f;
                        OnEnemyCaptured?.Invoke(this, EventArgs.Empty);
                        Debug.Log("Captured");
                    }
                    if (progress >= 1f)
                    {
                        faction = Faction.Civilization;
                        enemyProgress = 0f;
                        OnCaptured?.Invoke(this, EventArgs.Empty);
                        Debug.Log("Regained");
                    }
                    break;
            }
           
        }

        public float GetProgress()
        {
            return progress;
        }

        public float GetDEFProgress()
        {
            return enemyProgress;
        }

    }
}

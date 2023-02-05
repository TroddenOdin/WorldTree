using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WorldTree.Core
{ 
public class MapAreascapturingUI : MonoBehaviour
{
        [SerializeField] private List<MapArea> mapAreaList;

        private MapArea mapArea;
        private Image progressImage;
        private Image factionImage;

        private void Awake()
        {
            progressImage = transform.Find("ProgressImage").GetComponent<Image>();
            factionImage = transform.Find("FactionImage").GetComponent<Image>();
           
        }


        private void Start()
        {
            foreach (MapArea mapArea in mapAreaList)
            {
                mapArea.OnPlayerEnter += MapArea_OnPlayerEnter;
                mapArea.OnPlayerExit += MapArea_OnPlayerExit;
            }
            
           
        }


        private void Update()
        {
            progressImage.fillAmount = mapArea.GetProgress();
            progressImage.fillAmount = mapArea.GetDEFProgress();
        }
        private void MapArea_OnPlayerExit(object sender, EventArgs e)
        {
            Hide();
        }

        private void MapArea_OnPlayerEnter(object sender, EventArgs e)
        {
            mapArea = sender as MapArea;
            Show();
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }

    }
}

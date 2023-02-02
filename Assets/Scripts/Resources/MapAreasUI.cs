using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WorldTree.Core
{


    public class MapAreasUI : MonoBehaviour
    {
        [System.Serializable]
        public class MapAreaImage
        {
            public Image uImage;
            public MapArea mapArea;

        }

        [SerializeField] private List<MapAreaImage> mapAreaImgeList;


        private void Start()
        {
            foreach(MapAreaImage mapAreaImage in mapAreaImgeList)
            {
                mapAreaImage.mapArea.OnCaptured += (object sender, EventArgs e) =>
                {
                    mapAreaImage.uImage.color = Color.magenta;
                };
            }
        }








    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace WorldTree.Core
{
    public class ManaWellArea : MonoBehaviour
    {
        public Faction faction;

        public event EventHandler OnPlayerEnter;
        public event EventHandler OnPlayerExit;

        private List<SkyTest> skyTestList = new List<SkyTest>();

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out SkyTest skytest) && collider.GetComponent<SkyTest>().type != this.faction){
                skyTestList.Add(skytest);
                OnPlayerEnter?.Invoke(this, EventArgs.Empty);
                Debug.Log("Enemy Player Entered");
            }
            if (collider.TryGetComponent(out SkyTest skytestT) && collider.GetComponent<SkyTest>().type == this.faction)
            {
                skyTestList.Add(skytestT);
                OnPlayerEnter?.Invoke(this, EventArgs.Empty);
                Debug.Log("Reduce Capture and Restore");
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.TryGetComponent(out SkyTest skytest) && collider.GetComponent<SkyTest>().type != this.faction){
                skyTestList.Remove(skytest);
                OnPlayerExit?.Invoke(this, EventArgs.Empty);
                Debug.Log("Enemy Player Exited");
            }
            if (collider.TryGetComponent(out SkyTest skytestT) && collider.GetComponent<SkyTest>().type == this.faction)
            {
                skyTestList.Remove(skytestT);
                OnPlayerExit?.Invoke(this, EventArgs.Empty);
                Debug.Log("Reduce Capture and Restore");
            }
            
        }

        public List<SkyTest> GetSkyTestList()
        {
            return skyTestList;
        }

    }
}


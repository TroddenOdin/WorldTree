using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    public class Unit : MonoBehaviour, IDamageable
    {
      

       public void Start()
        {
            UnitSelections.Instance.unitList.Add(this.gameObject);
        }


        void OnDestroy()
        {
            UnitSelections.Instance.unitList.Remove(this.gameObject);
        }

        public void Damage(float damage)
        {
            throw new System.NotImplementedException();
        }

        public void Heal(float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}

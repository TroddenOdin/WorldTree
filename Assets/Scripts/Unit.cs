using UnityEngine;

namespace WorldTree
{
    public class Unit : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private SOUnit _stats;
        public SOUnit stats => _stats;

        private void Start()
        {
            UnitSelections.Instance.unitList.Add(this.gameObject);
        }


        private void OnDestroy()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace WorldTree
{
    public interface IDamageable
    {
        public void Damage(float damage);
        public void Heal(float health);
        public void Die();
    }
}

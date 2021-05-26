using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class SwordTrigger : MonoBehaviour
    {
        const int DAMAGE = 1;

        public Action<Collider, int> SwordAttackAction;

        private void OnTriggerEnter(Collider _collider)
        {
            if (!_collider.isTrigger && _collider.GetComponent<Enemy>())
            {
                SwordAttackAction.Invoke(_collider, DAMAGE);              
            }
        }
    }
}

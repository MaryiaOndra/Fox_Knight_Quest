using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class AttackTrigger : MonoBehaviour
    {
        const int DAMAGE = 1;

        public Action AttackAction;

        private void OnTriggerEnter(Collider _collider)
        {
            if (!_collider.isTrigger && _collider.GetComponent<Enemy>())
            {
                _collider.GetComponent<Enemy>().TakeDamage(DAMAGE);
                AttackAction.Invoke();
            }
        }
    }
}

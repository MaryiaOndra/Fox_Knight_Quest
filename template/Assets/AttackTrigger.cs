using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class AttackTrigger : MonoBehaviour
    {
        int Damage => 1;

        //public bool IsTouchEnemy { get; private set; }

        public Action<int> SwordAttack;

        private void OnTriggerEnter(Collider _collider)
        {
            if (!_collider.isTrigger && _collider.GetComponent<Enemy>())
            {
                //IsTouchEnemy = true;

                SwordAttack.Invoke(Damage);
            }
        }

        private void OnTriggerExit(Collider _collider)
        {
            if (!_collider.isTrigger && _collider.GetComponent<Enemy>())
            {
                //IsTouchEnemy = false;
            }
        }
    }
}

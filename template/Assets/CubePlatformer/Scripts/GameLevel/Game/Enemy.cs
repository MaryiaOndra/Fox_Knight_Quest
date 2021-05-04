using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Enemy : MonoBehaviour
    {
        static readonly int INT_STATE = Animator.StringToHash("State");

        [SerializeField]
        int maxHealth;
        [SerializeField]
        int attackPower;

        int enemyHealth;
        Animator enemyAnimator;

        Action<int> AttackAction;

        private void OnEnable()
        {
            AttackAction += Attack;
        }

        private void OnDisable()
        {
            AttackAction -= Attack;
        }

        void Awake()
        {
            enemyAnimator = GetComponent<Animator>();
            enemyHealth = maxHealth;            
        }

        public void Attack(int _attackPower) 
        {
            enemyAnimator.SetInteger(INT_STATE, (int)EnemyState.Attack);
        }

        public void TakeDamage(int _damage) 
        {
            enemyHealth -= _damage;
        }

        private void OnTriggerEnter(Collider _collision)
        {
            if (_collision.gameObject.GetComponent<PlayerController>())
            {
                Debug.Log("Enemy Attack!");
                transform.LookAt(_collision.transform, Vector3.up);
                AttackAction.Invoke(attackPower);
            }
        }
    }
}

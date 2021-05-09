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
        EnemyConfig slimeConfig;

        int enemyHealth;
        Animator enemyAnimator;
        float timePassed = 0;

        public Action<int> AttackAction;

        void Awake()
        {
            enemyAnimator = GetComponent<Animator>();
            enemyHealth = slimeConfig.MaxHealth;            
        }

        void Attack(int _attackPower) 
        {
            enemyAnimator.SetInteger(INT_STATE, (int)EnemyState.Attack);
            AttackAction.Invoke(_attackPower);
        }

        public void TakeDamage(int _damage) 
        {
            enemyHealth -= _damage;
        }
        

        private void OnTriggerStay(Collider _collision)
        {
            if (_collision.gameObject.GetComponent<PlayerController>())
            {
                transform.LookAt(_collision.transform, Vector3.up);

                enemyAnimator.SetInteger(INT_STATE, (int)EnemyState.IdleBattle);
                                
                timePassed += Time.deltaTime;

                if (timePassed > slimeConfig.AttackDelay)
                {
                    Attack(slimeConfig.AttackPower);
                    timePassed = 0;
                }         
            }
        }

        private void OnTriggerExit(Collider _collision)
        {
            if (_collision.gameObject.GetComponent<PlayerController>())
            {
                enemyAnimator.SetInteger(INT_STATE, (int)EnemyState.Idle);
            }
        }
    }
}

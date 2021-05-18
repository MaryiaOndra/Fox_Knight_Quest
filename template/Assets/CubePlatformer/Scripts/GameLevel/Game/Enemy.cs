using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Enemy : MonoBehaviour
    {
        static readonly int INT_STATE = Animator.StringToHash("State");
        static readonly int GET_HIT = Animator.StringToHash("GetHit");
        static readonly int ATTACK = Animator.StringToHash("Attack");

        [SerializeField]
        EnemyConfig slimeConfig;

        int enemyHealth;
        Animator enemyAnimator;
        float timePassed = 0;
        bool IsDead = false;

        public Action<int> AttackAction;

        void Awake()
        {
            enemyAnimator = GetComponent<Animator>();
            enemyHealth = slimeConfig.MaxHealth;
            enemyAnimator.SetInteger(INT_STATE, (int)EnemyState.Idle);
        }

        void Attack(int _attackPower) 
        {
            enemyAnimator.SetTrigger(ATTACK);
            AttackAction.Invoke(_attackPower);
        }

        public void TakeDamage(int _damage) 
        {
            enemyHealth -= _damage;
            enemyAnimator.SetTrigger(GET_HIT);

            if (enemyHealth <= 0)
            {
                IsDead = true;
                enemyAnimator.SetInteger(INT_STATE, (int)EnemyState.Die);
                GetComponent<Collider>().enabled = false;
            }
        }

        private void OnTriggerStay(Collider _collision)
        {
            if (_collision.gameObject.GetComponent<PlayerController>() && !IsDead)
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
            if (_collision.gameObject.GetComponent<PlayerController>() && !IsDead)
            {
                enemyAnimator.SetInteger(INT_STATE, (int)EnemyState.Idle);
            }
        }
    }
}

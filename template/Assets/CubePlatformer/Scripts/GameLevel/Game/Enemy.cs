using System;
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

        [SerializeField]
        AudioClip attack;

        AudioSource audioSource;
        Animator enemyAnimator;
        float timePassed;
        int enemyHealth;
        bool IsDead = false;

        public Action<int> AttackAction;

        void Awake()
        {
            enemyAnimator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            enemyHealth = slimeConfig.MaxHealth;
            enemyAnimator.SetInteger(INT_STATE, (int)EnemyState.Idle);
        }

        void Attack(int _attackPower) 
        {
            AttackAction.Invoke(_attackPower);
            enemyAnimator.SetTrigger(ATTACK);
            audioSource.PlayOneShot(attack);
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

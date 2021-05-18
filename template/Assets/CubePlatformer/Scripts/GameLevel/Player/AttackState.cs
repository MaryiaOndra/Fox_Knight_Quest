using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class AttackState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Attack;

        const int DAMAGE = 1;

        [SerializeField]
        AudioClip attackClip;

        AttackTrigger sword;
        Collider swordCollider;

        private void Awake()
        {
            sword = FindObjectOfType<AttackTrigger>();
            sword.SwordAttack = Attack;
        }

        void Attack(int _damage) 
        {
            GetComponentInParent<PlayerController>().PlayerAttack.Invoke(_damage);
        }

        public override void Activate()
        {
            base.Activate();

            playerAudioSource.PlayOneShot(attackClip);
        }

        private void Update()
        {
            if (!VirtualInputManager.Instance.Attack)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class AttackState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Attack;

        [SerializeField]
        AudioClip emptyAttack;     

        [SerializeField]
        AudioClip monsterAttack;

        AttackTrigger swordTrigger;

        private void Awake()
        {
            swordTrigger = FindObjectOfType<AttackTrigger>();
            swordTrigger.AttackAction = AttackMonster;
        }

        public override void Activate()
        {
            base.Activate();
            playerAudioSource.PlayOneShot(emptyAttack);
        }

        void AttackMonster() 
        {
            playerAudioSource.PlayOneShot(monsterAttack);
        }

        private void Update()
        {
            if (!VirtualInputManager.Instance.Attack)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
            else if (Direction.x != 0 || Direction.z != 0)
            {
                NextStateAction.Invoke(PlayerState.Run);
            }
            else if (VirtualInputManager.Instance.Defend)
            {
                NextStateAction.Invoke(PlayerState.Defend);
            }
        }
    }
}

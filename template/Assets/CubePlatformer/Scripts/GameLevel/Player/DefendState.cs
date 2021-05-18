using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class DefendState : BaseState
    {
        [SerializeField]
        AudioClip defend;

        public override PlayerState PlayerState => PlayerState.Defend;

        public override void Activate()
        {
            base.Activate();

            playerAudioSource.PlayOneShot(defend);
        }

        private void Update()
        {
            if (!VirtualInputManager.Instance.Defend)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
            else if (IsAttackFinished && VirtualInputManager.Instance.Attack)
            {
                NextStateAction.Invoke(PlayerState.Attack);
            }
        }
    }
}

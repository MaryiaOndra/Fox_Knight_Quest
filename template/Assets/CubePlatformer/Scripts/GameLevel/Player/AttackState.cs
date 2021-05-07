using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class AttackState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Attack;

        public override void Activate()
        {
            base.Activate();

            playerAnimator.SetInteger(INT_STATE, (int)PlayerState.Attack);
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

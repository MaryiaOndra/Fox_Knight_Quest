using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class DefendState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Defend;

        public override void Activate()
        {
            base.Activate();

            playerAnimator.SetInteger(INT_STATE, (int)PlayerState.Defend);
        }

        private void Update()
        {
            if (!VirtualInputManager.Instance.Defence)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
        }
    }
}

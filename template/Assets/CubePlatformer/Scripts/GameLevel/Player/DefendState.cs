using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class DefendState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Defend;

        private void Update()
        {
            if (!VirtualInputManager.Instance.Defend)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class IdleState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Idle;

        void Update()
        {

            if (Direction.x != 0 || Direction.z != 0)
            {
                NextStateAction.Invoke(PlayerState.Run);
            }
            else if (IsAttackFinished && VirtualInputManager.Instance.Attack)
            {
                NextStateAction.Invoke(PlayerState.Attack);
            }
            else if (VirtualInputManager.Instance.Defend)
            {
                NextStateAction.Invoke(PlayerState.Defend);
            }
            else
            {
                playerRB.velocity = Vector3.zero;
            }
        }
    }
}

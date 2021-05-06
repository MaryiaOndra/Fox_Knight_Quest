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
            else if (Input.GetMouseButtonDown(0))
            {
                NextStateAction.Invoke(PlayerState.Attack);
            }
            else if (Input.GetMouseButton(1))
            {
                NextStateAction.Invoke(PlayerState.Defend);
            }
            else
            {
                rigidbody.velocity = Vector3.zero;
            }
        }
    }
}

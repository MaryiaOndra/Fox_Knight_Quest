using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class IdleState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Idle;

        private void FixedUpdate()
        {
            if (VerticalValue != 0)
            {
                NextStateAction.Invoke(PlayerState.Run);
            }
            else if (JumpValue != 0)
            {
                NextStateAction.Invoke(PlayerState.Jump);
            }
            else
            {
                var _velocity = rBody.velocity;
                _velocity.x = 0;
                rBody.velocity = _velocity;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class IdleState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Idle;

        void FixedUpdate()
        {
            if (VerticalValue != 0 || HorizontalValue != 0)
            {
                NextStateAction.Invoke(PlayerState.Run);
            }
            else if (JumpValue != 0)
            {
                NextStateAction.Invoke(PlayerState.Jump);
            }
            else
            {
                var _velocity = rigidbody.velocity;
                _velocity = Vector3.zero;
                rigidbody.velocity = _velocity;
            }
        }
    }
}

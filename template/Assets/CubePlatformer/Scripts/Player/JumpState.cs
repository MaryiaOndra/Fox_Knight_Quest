using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class JumpState : BaseState
    {
        [SerializeField]
        float jumpForce;
        [SerializeField]
        float moveSpeed;

        float deadlineVelocity = -5.0f;

        public override PlayerState PlayerState => PlayerState.Jump;

        public override void Activate()
        {
            base.Activate();

            //var _velocity = rBody.velocity;
            //_velocity.y += Vector3.up.y * jumpForce;
            //rBody.velocity = _velocity;
        }

        private void FixedUpdate()
        {
            var _velocity = rBody.velocity;
            _velocity.z = Vector3.forward.z * moveSpeed * VerticalValue;
            rBody.velocity = _velocity;

            if (IsGrounded)
            {
                if (_velocity.z == 0)
                {
                    NextStateAction.Invoke(PlayerState.Idle);
                }
                else
                {
                    NextStateAction.Invoke(PlayerState.Run);
                }
            }
            else if (_velocity.y < deadlineVelocity)
            {
                NextStateAction.Invoke(PlayerState.Fall);
            }

            //if (IsGrounded)
            //{
            //    if (VerticalValue == 0)
            //    {
            //        NextStateAction.Invoke(PlayerState.Idle);
            //    }
            //    else
            //    {
            //        NextStateAction.Invoke(PlayerState.Run);
            //    }
            //}
        }
    }
}

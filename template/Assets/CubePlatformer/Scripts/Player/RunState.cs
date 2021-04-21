using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class RunState : BaseState
    {
        [SerializeField]
        float moveSpeed;
        [SerializeField]
        float rotationSpeed;

        float deadlineVelocity = -5.0f;

        public override PlayerState PlayerState => PlayerState.Run;

        private void FixedUpdate()
        {
            var _velocity = rBody.velocity;
            //_velocity.x = Vector3.forward.x * moveSpeed * VerticalValue;
            //rBody.velocity = _velocity;

            _velocity = new Vector3(-VerticalValue, rBody.velocity.y, HorizontalValue) * moveSpeed;
            rBody.velocity = _velocity;

            if (IsGrounded)
            {
                Debug.Log(name + "  IsGrounded");

                if (JumpValue > 0)
                {
                    NextStateAction.Invoke(PlayerState.Jump);
                }
                else if (_velocity == Vector3.zero)
                {
                    NextStateAction.Invoke(PlayerState.Idle);
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
            //}
        }
    }
}

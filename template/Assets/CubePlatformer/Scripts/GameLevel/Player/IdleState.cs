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
            float _horAxes = Input.GetAxis("Horizontal");
            float _vertAxes = Input.GetAxis("Vertical");
            float _jumpAxes = Input.GetAxis("Jump");

            if (_vertAxes != 0 || _horAxes != 0)
            {
                NextStateAction.Invoke(PlayerState.Run);
            }
            else if (_jumpAxes > 0)
            {
                NextStateAction.Invoke(PlayerState.Jump);
            }
            else
            {
                //var _velocity = rigidbody.velocity;
                //_velocity.x = 0;
                //_velocity.z = 0;
                rigidbody.velocity = Vector3.zero;
            }
        }
    }
}

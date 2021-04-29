using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class RunState : BaseState
    {
        [SerializeField]
        Camera camera;
        [SerializeField]
        float playerSpeed = 2.0f;

        public override PlayerState PlayerState => PlayerState.Run;


        private void FixedUpdate()
        {

            Vector3 _movementX = camera.transform.right * HorizontalValue;
            Vector3 _movementZ = camera.transform.forward * VerticalValue;
            Vector3 _movement = _movementX + _movementZ;

            rigidbody.MovePosition(transform.position + _movement * Time.fixedDeltaTime * playerSpeed);

            if (floorTrigger.IsGrounded)
            {
                if (JumpValue > 0)
                {
                    NextStateAction.Invoke(PlayerState.Jump);
                }
                //else if(VerticalValue == 0 && HorizontalValue == 0)
                //{
                //    NextStateAction.Invoke(PlayerState.Idle);
                //}
            }
        }
    }
}

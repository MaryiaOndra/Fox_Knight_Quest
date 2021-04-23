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

        float gravityValue = -9.81f;
        float jumpHeight = 0.1f;

        public override PlayerState PlayerState => PlayerState.Jump;
        public override void Activate()
        {
            base.Activate();

            var _direction2 = new Vector3(VerticalValue * -1, JumpValue * jumpForce, HorizontalValue).normalized;
            chController.Move(_direction2);
        }


        private void Update()
        {

        }
    }
}

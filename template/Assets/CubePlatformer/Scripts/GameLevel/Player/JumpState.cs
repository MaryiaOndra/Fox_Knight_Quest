using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class JumpState : BaseState
    {
        [SerializeField]
        float jumpForce = 3.0f;
        [SerializeField]
        float playerSpeed = 2.0f;

        public override void Activate()
        {
            base.Activate();

            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        public override PlayerState PlayerState => PlayerState.Jump;

        private void FixedUpdate()
        {
            //Vector3 m_Input = new Vector3(VerticalValue * -1, rigidbody.position.y, HorizontalValue);

            //rigidbody.MovePosition(transform.position + m_Input * Time.fixedDeltaTime * playerSpeed);
            //float _targetAngle = Mathf.Atan2(m_Input.x, m_Input.z) * Mathf.Rad2Deg;
            //rigidbody.rotation = Quaternion.Euler(0f, _targetAngle, 0f);

            if (OnGrounded)
            {
                if (VerticalValue != 0 || HorizontalValue != 0)
                {
                    NextStateAction.Invoke(PlayerState.Run);
                }
                else
                {
                    NextStateAction.Invoke(PlayerState.Idle);
                }
            }   
        }
    }
}

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
            rigidbody.AddForce(Vector3.up * jumpForce);
        }

        public override PlayerState PlayerState => PlayerState.Jump;

        float horAxes;
        float vertAxes;
        float jumpAxes;

        private void Update()
        {
            horAxes = Input.GetAxis("Horizontal");
            vertAxes = Input.GetAxis("Vertical");
            jumpAxes = Input.GetAxis("Jump");

            //Vector3 m_Input = new Vector3(VerticalValue * -1, rigidbody.position.y, HorizontalValue);

            //rigidbody.MovePosition(transform.position + m_Input * Time.fixedDeltaTime * playerSpeed);
            //float _targetAngle = Mathf.Atan2(m_Input.x, m_Input.z) * Mathf.Rad2Deg;
            //rigidbody.rotation = Quaternion.Euler(0f, _targetAngle, 0f);

            if (OnGrounded)
            {
                if (vertAxes > 0 || horAxes > 0)
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

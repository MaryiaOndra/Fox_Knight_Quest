using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class RunState : BaseState
    {
        [SerializeField]
        float playerSpeed = 2.0f;

        public override PlayerState PlayerState => PlayerState.Run;

        private void FixedUpdate()
        {
            Vector3 m_Input = new Vector3(VerticalValue * -1, 0, HorizontalValue);

            rigidbody.MovePosition(transform.position + m_Input * Time.fixedDeltaTime * playerSpeed);
            float _targetAngle = Mathf.Atan2(m_Input.x, m_Input.z) * Mathf.Rad2Deg;
            rigidbody.rotation = Quaternion.Euler(0f, _targetAngle, 0f);

            //if (OnGrounded)
            //{
            //    if (JumpValue != 0)
            //    {
            //        NextStateAction.Invoke(PlayerState.Jump);
            //    }
            //    else if (VerticalValue == 0 || HorizontalValue == 0)
            //    {
            //        NextStateAction.Invoke(PlayerState.Idle);
            //    }
            //}
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class IdleState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Idle;

        [SerializeField]
        float playerSpeed = 2.0f;
        [SerializeField]
        float jumpHeight = 1.0f;

        float gravityValue = -9.81f;
        Vector3 playerVelocity;

        void Update()
        {

            bool groundedPlayer = chController.isGrounded;

            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(VerticalValue * -1, 0, HorizontalValue).normalized;
            chController.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;

            }

            if (JumpValue != 0f && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;

            if (VerticalValue != 0 || HorizontalValue != 0)
            {
                float _targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
                chController.transform.rotation = Quaternion.Euler(0f, _targetAngle, 0f);
            }

            chController.Move(playerVelocity * Time.deltaTime);

        }
    }
}

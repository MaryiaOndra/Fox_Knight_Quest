using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class RunState : BaseState
    {
        [SerializeField]
        Transform cameraTr;
        [SerializeField]
        float playerSpeed = 2.0f;
        [SerializeField]
        float rotationSpeed = 500f;

        public override PlayerState PlayerState => PlayerState.Run;

        private void FixedUpdate()
        {
            Vector3 _camR = cameraTr.right;
            Vector3 _camF = cameraTr.forward;
            _camF.y = 0;
            _camR.y = 0;
            _camF = _camF.normalized;
            _camR = _camR.normalized;

            Vector3 _direction = (_camF * Direction.z + _camR * Direction.x).normalized;
            playerRB.MovePosition(playerRB.position + Time.deltaTime * playerSpeed * _direction);
            Quaternion _toRotation = Quaternion.LookRotation(_direction);
            playerRB.rotation = Quaternion.RotateTowards(playerRB.rotation, _toRotation, Time.fixedDeltaTime * rotationSpeed);
        }

        private void Update()
        {
            if (OnGrounded)
            {
                if (Direction.x == 0 && Direction.z == 0)
                {
                    NextStateAction.Invoke(PlayerState.Idle);
                }
            }
            else if (playerRB.velocity.y < -3f)
            {

                NextStateAction.Invoke(PlayerState.Fall);
            }            
        }
    }
}

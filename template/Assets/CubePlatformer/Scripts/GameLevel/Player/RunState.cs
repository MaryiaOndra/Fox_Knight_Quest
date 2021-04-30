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

        Vector3 movementX;
        Vector3 movementZ;
        Vector3 movement;

        float horAxes;
        float vertAxes;
        float jumpAxes; 

        private void Update()
        {
           horAxes = Input.GetAxis("Horizontal");
            vertAxes = Input.GetAxis("Vertical");
            jumpAxes = Input.GetAxis("Jump");

            movementX = camera.transform.right * horAxes;
            movementZ = camera.transform.forward * vertAxes;
            movement = movementX + movementZ;

            Debug.Log("HorizontalV:" + horAxes + "VerticalV: " + vertAxes);
            // rigidbody.MovePosition(transform.position + movement * Time.fixedDeltaTime * playerSpeed );
            rigidbody.MovePosition(transform.position + Time.deltaTime * playerSpeed * transform.TransformDirection(movement.normalized));

            CheckState();

        }

        void CheckState() 
        {
            if (OnGrounded)
            {
                if (jumpAxes > 0)
                {
                    NextStateAction.Invoke(PlayerState.Jump);
                }
                else if (horAxes == 0 && vertAxes == 0)
                {
                    NextStateAction.Invoke(PlayerState.Idle);
                }
            }
        }
    }
}

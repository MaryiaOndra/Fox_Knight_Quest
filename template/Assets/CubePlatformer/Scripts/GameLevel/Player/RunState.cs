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

        public override PlayerState PlayerState => PlayerState.Run;

        Vector3 camR;
        Vector3 camF;
        Vector3 movement;     
        
        Vector3 cameraRight;
        Vector3 cameraLeft;

        float rotationSpeed = 500f;

        float horAxes;
        float vertAxes;
        float jumpAxes; 

        private void FixedUpdate()
        {
            //TODO: make from in Vector patameter;
           horAxes = Input.GetAxis("Horizontal");
            vertAxes = Input.GetAxis("Vertical");
            jumpAxes = Input.GetAxis("Jump");

            camR = cameraTr.right;
            camF = cameraTr.forward;
            camF.y = 0;
            camR.y = 0;
            camF = camF.normalized;
            camR = camR.normalized;

            Vector3 _direction = camF * vertAxes + camR * horAxes;
            //rigidbody.MovePosition(transform.position + movement * Time.fixedDeltaTime * playerSpeed );

            //Vector3 _direction = new Vector3(horAxes, 0f, vertAxes).normalized;


            rigidbody.MovePosition(rigidbody.position + Time.deltaTime * playerSpeed * _direction);

            Quaternion _toRotation = Quaternion.LookRotation(_direction/*, rigidbody.transform.up*/);
            rigidbody.rotation = Quaternion.RotateTowards(rigidbody.rotation, _toRotation, Time.fixedDeltaTime * rotationSpeed);

           // rigidbody.rotation = _toRotation;
        }

        private void Update()
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

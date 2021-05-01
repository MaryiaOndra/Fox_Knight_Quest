using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class JumpState : BaseState
    {
        //TODO: add code if it need

        public override PlayerState PlayerState => PlayerState.JumpNoNeedYet;

        //[SerializeField]
        //float jumpForce = 200f;
        //[SerializeField]
        //float playerSpeed = 10f;

        //public override void Activate()
        //{
        //    base.Activate();    
        //    rigidbody.AddForce(Vector3.up * jumpForce);
        //}

        //float horAxes;
        //float vertAxes;
        //float jumpAxes;

        //private void Update()
        //{
        //    horAxes = Input.GetAxis("Horizontal");
        //    vertAxes = Input.GetAxis("Vertical");
        //    jumpAxes = Input.GetAxis("Jump");

        //    Vector3 _direction = new Vector3(horAxes, jumpAxes, vertAxes);

        //    rigidbody.MovePosition(transform.position + Time.deltaTime * playerSpeed * transform.TransformDirection(_direction.normalized));

        //    if (OnGrounded)
        //    {
        //        if (vertAxes > 0 || horAxes > 0)
        //        {
        //            NextStateAction.Invoke(PlayerState.Run);
        //        }
        //        else 
        //        {
        //            NextStateAction.Invoke(PlayerState.Idle);        
        //        }

        //    }   
        //}
    }
}

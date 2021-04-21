using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody rBody;
        Animator playerAnimator;
        Collider playerCollider;
        List<BaseState> states;
        BaseState currentState;

        private void Awake()
        {
            rBody = GetComponent<Rigidbody>();
            playerAnimator = GetComponent<Animator>();
            playerCollider = GetComponent<Collider>();
            states = new List<BaseState>(GetComponentsInChildren<BaseState>(true));

            states.ForEach(_state =>
            {
                _state.Setup(rBody, playerAnimator, playerCollider);
                _state.NextStateAction = OnNextStateRequest;
            });

            currentState = states.Find(_state => _state.PlayerState == PlayerState.Idle);
            currentState.Activate();
        }

        public void OnNextStateRequest(PlayerState _state) 
        {
            currentState.Diactivate();
            currentState = states.Find(_s => _s.PlayerState == _state);
            currentState.Activate();
        }

        void FixedUpdate()
        {
            //float _horizontalAxis = Input.GetAxis("Horizontal");
            //float _verticalAxis = Input.GetAxis("Vertical");
            //float _jumpAxis = Input.GetAxis("Jump");


            //rBody.MovePosition(transform.position + transform.forward * _verticalAxis * Time.fixedDeltaTime * moveSpeed);
            //rBody.AddForce(transform.up * _jumpAxis * jumpForce);
            //Quaternion quaternion = Quaternion.Euler(Vector3.up * rotationSpeed * _horizontalAxis *  Time.fixedDeltaTime);
            //rBody.MoveRotation(rBody.rotation * quaternion);
            
        }
    }
}

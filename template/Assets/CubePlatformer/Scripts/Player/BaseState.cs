using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public abstract class BaseState : MonoBehaviour
    {
        static readonly int INT_STATE = Animator.StringToHash("State");

        protected Rigidbody rBody;
        protected Animator playerAnimator;
        protected Collider playerCollider;

        public abstract PlayerState PlayerState { get; }
        public Action<PlayerState> NextStateAction { get; set; }

        public void Setup(Rigidbody _rBody, Animator _playerAniimator, Collider _playerCollider) 
        {
            rBody = _rBody;
            playerAnimator = _playerAniimator;
            playerCollider = _playerCollider;
        }

        public virtual void Activate() 
        {
            gameObject.SetActive(true);
            playerAnimator.SetInteger(INT_STATE, (int)PlayerState);
        }

        public virtual void Diactivate() 
        {
            gameObject.SetActive(false);        
        }

        private void OnCollision(Collision collision)
        {
            
        }

        protected bool IsGrounded
        {
            get 
            {
                bool _value = false;
                float _minDist = 1f;
                float _distToGround = playerCollider.bounds.extents.y;

                bool _isTouchGround = Physics.Raycast(rBody.position, Vector3.down, _minDist /*+ _distToGround*/);

                if (_isTouchGround)
                    _value = true;
                else
                    _value = false;

                return _value;            
            }        
        }

        protected float HorizontalValue
        {
            get
            {
                float _horizontalValue = Input.GetAxis("Horizontal");
                return _horizontalValue;
            }
        }

        protected float VerticalValue
        {
            get
            {
                float _verticalValue = Input.GetAxis("Vertical");
                return _verticalValue;
            }
        }

        protected float JumpValue
        {
            get
            {
                float _jumpValue = Input.GetAxis("Jump");
                return _jumpValue;
            }
        }
    }
}

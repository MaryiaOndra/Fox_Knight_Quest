using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public abstract class BaseState : MonoBehaviour
    {
        static readonly int INT_STATE = Animator.StringToHash("State");

        //protected Rigidbody rBody;
        protected Animator playerAnimator;
        protected Collider playerCollider;
        protected CharacterController chController;
        protected BtnState btnAction = BtnState.None;

       public Vector3 PlayerVelosityTestBase { get; set; }


        public abstract PlayerState PlayerState { get; }
        public Action<PlayerState> NextStateAction { get; set; }

        public void Setup(CharacterController _chController, Animator _playerAniimator) 
        {
           // rBody = _rBody;
            playerAnimator = _playerAniimator;
            chController = _chController;
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

        private void AddValuesFromBtn() 
        {
        
        }


        protected float HorizontalValue
        {
            get
            {
                float _horizontalValue = Input.GetAxisRaw("Horizontal");
                return _horizontalValue;
            }
        }

        protected float VerticalValue
        {
            get
            {
                float _verticalValue = Input.GetAxisRaw("Vertical");
                return _verticalValue;
            }
        }

        protected float JumpValue
        {
            get
            {
                float _jumpValue = Input.GetAxisRaw("Jump");
                return _jumpValue;
            }
        }
    }
}

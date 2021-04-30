using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public abstract class BaseState : MonoBehaviour
    {
        static readonly int INT_STATE = Animator.StringToHash("State");

        protected Animator playerAnimator;
        protected Collider playerCollider;
        protected Collider collider;
        protected Rigidbody rigidbody;
        protected FloorTrigger floorTrigger;


        public abstract PlayerState PlayerState { get; }
        public Action<PlayerState> NextStateAction { get; set; }
        public float PlatformAngle { get; set; }
        public float HorizontalValue { get; set; }
        public float VerticalValue { get; set; }
        public float JumpValue { get; set; }

        //protected float HorizontalV
        //{
        //    get 
        //    {
        //        float _value = Input.GetAxis("Horizontal");
        //        return _value;
        //    }
        //}
        
        //protected float VerticalV
        //{
        //    get 
        //    {
        //        float _value = Input.GetAxis("Vertical");
        //        return _value;
        //    }
        //}
        
        //protected float JumpV
        //{
        //    get 
        //    {
        //        float _value = Input.GetAxis("Jump");
        //        return _value;
        //    }
        //}

        protected bool OnGrounded 
        {
            get 
            {
                var _value = false;
                float _distToGround = 0.5f;                   

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * _distToGround, Color.blue);
                RaycastHit _hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out _hit, _distToGround))
                {
                    _value = true;
                }
                else
                {
                    _value = false;
                }

                return _value;            
            }
        }

        public void Setup(Collider _collider, Animator _playerAniimator, Rigidbody _rigidbody) 
        {
            playerAnimator = _playerAniimator;
            collider = _collider;
            rigidbody = _rigidbody;
        }

        public virtual void Activate() 
        {
            gameObject.SetActive(true);
            Debug.Log(gameObject.name);
            playerAnimator.SetInteger(INT_STATE, (int)PlayerState);
        }

        public virtual void Diactivate() 
        {
            gameObject.SetActive(false);        
        }

        public void OnTrigger(Collider _trigger)
        {
            if (_trigger.GetComponent<DeathLine>())
            {
                Debug.Log("GameOver: call result screen");
                NextStateAction.Invoke(PlayerState.Die);
            }
        }
    }
}

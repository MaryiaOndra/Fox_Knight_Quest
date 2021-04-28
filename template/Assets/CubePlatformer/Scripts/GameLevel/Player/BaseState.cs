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

        public abstract PlayerState PlayerState { get; }
        public Action<PlayerState> NextStateAction { get; set; }
        public float PlatformAngle { get; set; }
        public float HorizontalValue { get; set; }
        public float VerticalValue { get; set; }
        public float JumpValue { get; set; }

        public bool OnGrounded 
        {
            get 
            {
                var _value = false;
                float _distToGround = 0.5f;
                _value = Physics.Raycast(transform.position, -Vector3.up, _distToGround);
                Debug.DrawRay(transform.position, -Vector3.up, Color.red ,(_distToGround + 0.1f));
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

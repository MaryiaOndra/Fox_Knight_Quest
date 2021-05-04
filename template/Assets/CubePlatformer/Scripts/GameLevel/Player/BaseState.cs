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

        protected Vector3 Direction
        {
            get
            {
                float _horAxes = Input.GetAxis("Horizontal");
                float _vertAxes = Input.GetAxis("Vertical");

                var _dir = new Vector3(_horAxes, 0f, _vertAxes);
                return _dir;
            }
        }

        protected bool OnGrounded
        {
            get
            {
                var _value = false;
                float _distToGround = 0.1f;
                if (Physics.Raycast(rigidbody.transform.position, Vector3.down, _distToGround))
                    _value = true;
                else
                    _value = false;

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
    }
}

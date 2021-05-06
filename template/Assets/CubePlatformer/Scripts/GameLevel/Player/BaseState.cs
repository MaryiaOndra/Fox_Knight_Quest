using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public abstract class BaseState : MonoBehaviour
    {
        static readonly int INT_STATE = Animator.StringToHash("State");
        static readonly int STATE_DIE = Animator.StringToHash("Die");
        static readonly int STATE_ATTACK = Animator.StringToHash("Attack01");
        static readonly int STATE_DEFEND = Animator.StringToHash("Defend");

        protected Animator playerAnimator;
        protected Collider playerCollider;
        protected Collider collider;
        protected Rigidbody rigidbody;


        public abstract PlayerState PlayerState { get; }
        public Action<PlayerState> NextStateAction { get; set; }
        //public Action DeathStateAction;
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

        public void Setup(Animator _playerAniimator, Rigidbody _rigidbody)
        {
            playerAnimator = _playerAniimator;
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

        //public void OnDied() 
        //{
        //    FindObjectOfType<PlayerController>().PlayerDeathAction.Invoke();
        //}

        private void OnEnable()
        {
            var _playerListeners = playerAnimator.GetBehaviours<PlayerListener>();
            Debug.Log("_playerListeners.Length" + _playerListeners.Length);
            foreach (var _listener in _playerListeners)
            {
                _listener.stateExitAction += OnAnimExit;
                _listener.stateEnterAction += OnAnimEnter;
            }
        }

        private void OnAnimEnter(AnimatorStateInfo _info)
        {
            if (_info.shortNameHash == STATE_ATTACK)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
        }

        private void OnAnimExit(AnimatorStateInfo _info)
        {
            if (_info.shortNameHash == STATE_DIE)
            {
                FindObjectOfType<PlayerController>().PlayerDeathAction.Invoke();
            }
            else if (_info.shortNameHash == STATE_ATTACK)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
        }
    }
}

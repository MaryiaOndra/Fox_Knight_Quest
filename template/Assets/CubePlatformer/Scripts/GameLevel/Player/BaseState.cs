using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public abstract class BaseState : MonoBehaviour
    {
        protected static readonly int INT_STATE = Animator.StringToHash("State");
        protected static readonly int ATTACK02 = Animator.StringToHash("Attack02");
        static readonly int STATE_DIE = Animator.StringToHash("Die");
        static readonly int STATE_ATTACK = Animator.StringToHash("Attack01");
        static readonly int STATE_DEFEND = Animator.StringToHash("Defend");

        protected Animator playerAnimator;
        protected Collider playerCollider;
        protected Collider collider;
        protected Rigidbody rigidbody;
        PlayerListener[] playerListeners;

        public abstract PlayerState PlayerState { get; }
        public Action<PlayerState> NextStateAction { get; set; }
        //public Action DeathStateAction;
        protected Vector3 Direction
        {
            get
            {
                float _horAxes = VirtualInputManager.Instance.MoveHorizontal;
                float _vertAxes = VirtualInputManager.Instance.MoveVertical;

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

        private void OnEnable()
        {
            playerListeners = playerAnimator.GetBehaviours<PlayerListener>();
            foreach (var _listener in playerListeners)
            {
                _listener.stateExitAction = OnAnimExit;
                //_listener.stateEnterAction = OnAnimEnter;
            }
        }

        private void OnAnimExit(AnimatorStateInfo _info)
        {
            if (_info.shortNameHash == STATE_DIE)
            {
                FindObjectOfType<PlayerController>().PlayerDeathAction.Invoke();
            }
            //else if (_info.shortNameHash == STATE_ATTACK)
            //{
                //if (!VirtualInputManager.Instance.Attack)
                //{
                //    NextStateAction.Invoke(PlayerState.Idle);
                //}
                //else
                //{
                //    playerAnimator.SetBool(ATTACK02, true);
                //}
            //}
        }
    }
}

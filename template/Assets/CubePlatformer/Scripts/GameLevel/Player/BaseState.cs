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


        protected Animator playerAnimator;
        protected Collider playerCollider;
        //protected Collider collider;
        protected Rigidbody playerRB;
        //PlayerListener[] playerListeners;
        protected AudioSource playerAudioSource;
        AttackListener attackListener;

        public abstract PlayerState PlayerState { get; }
        public Action<PlayerState> NextStateAction { get; set; }
        public Action DeathStateAction;
        public Action<int> AttackStateAction;


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
                if (Physics.Raycast(playerRB.transform.position, Vector3.down, _distToGround))
                    _value = true;
                else
                    _value = false;

                return _value;
            }
        }

        protected bool IsAttackFinished 
        {
            get 
            {
                var _value = true;
                _value = attackListener.IsAttackFinished;
                return _value;            
            }        
        }

        public void Setup(Animator _playerAniimator, Rigidbody _rigidbody, AudioSource _audioSource)
        {
            playerAnimator = _playerAniimator;
            playerRB = _rigidbody;
            playerAudioSource = _audioSource;

            attackListener = playerAnimator.GetBehaviour<AttackListener>();
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

        //private void OnEnable()
        //{
        //    playerListeners = playerAnimator.GetBehaviours<PlayerListener>();
        //    foreach (var _listener in playerListeners)
        //    {
        //        _listener.stateExitAction = OnAnimExit;
        //        //_listener.stateEnterAction = OnAnimEnter;
        //    }
        //}

        //private void OnAnimExit(AnimatorStateInfo _info)
        //{
        //    if (_info.shortNameHash == STATE_DIE)
        //    {
        //        FindObjectOfType<PlayerController>().PlayerDeathAction.Invoke();
        //    }
        //}
    }
}

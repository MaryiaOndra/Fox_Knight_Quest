using System;
using UnityEngine;

namespace CubePlatformer
{
    public abstract class BaseState : MonoBehaviour
    {
        protected static readonly int INT_STATE = Animator.StringToHash("State");
        protected static readonly int GET_HIT = Animator.StringToHash("GetHit");
        protected static readonly int VELOCITY_TO_FALL = -4;
        protected static readonly string GROUND_LAYER = "Ground";

        protected Animator playerAnimator;
        protected Collider playerCollider;
        protected Rigidbody playerRB;
        protected AudioSource playerAudioSource;
        protected AttackListener attackListener;

        public abstract PlayerState PlayerState { get; }
        public Vector3 LastIdlePosition { get; protected set; }

        public Action<PlayerState> NextStateAction { get; set; }
        public Action DeathStateAction;

        public void GetHit() 
        {
            playerAnimator.SetTrigger(GET_HIT);
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

                LayerMask _mask = LayerMask.GetMask(GROUND_LAYER);

                if (Physics.Raycast(playerRB.transform.position, Vector3.down, _distToGround, _mask)) 
                {
                    _value = true;
                    LastIdlePosition = playerRB.transform.position;
                }
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

    }
}

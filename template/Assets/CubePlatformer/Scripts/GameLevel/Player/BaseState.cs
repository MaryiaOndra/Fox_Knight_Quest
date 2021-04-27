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
        protected CharacterController chController;

        public abstract PlayerState PlayerState { get; }
        public float PlatformAngle { get; set; }
        public float HorizontalValue { get; set; }
        public float VerticalValue { get; set; }
        public float JumpValue { get; set; }
        public Action<PlayerState> NextStateAction { get; set; }

        public void Setup(CharacterController _chController, Animator _playerAniimator) 
        {
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

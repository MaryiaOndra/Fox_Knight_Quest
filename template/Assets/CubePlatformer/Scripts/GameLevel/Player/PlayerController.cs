using System;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        AudioClip getHit;

        public const int MAX_HEALTH = 3;
        int actualHealth;

        List<BaseState> states;
        BaseState currentState;
        AudioSource audioSource;

        public int PlayerHealth => actualHealth;

        public Action PlayerDeathAction;
        public Action PlayerReturnAction;
        public Action<int> ChangeHealthAction;

        private void Awake()
        {
            actualHealth = MAX_HEALTH;

            Animator _playerAnimator = GetComponent<Animator>();
            Rigidbody _rigidbody = GetComponent<Rigidbody>();
            audioSource = GetComponent<AudioSource>();

            states = new List<BaseState>(GetComponentsInChildren<BaseState>(true));

                states.ForEach(_state =>
                {
                    _state.Setup( _playerAnimator, _rigidbody, audioSource);
                    _state.NextStateAction = OnNextStateRequest;
                    _state.DeathStateAction = PlayerDeathAction;
                });

            currentState = states.Find(_state => _state.PlayerState == PlayerState.Fall);
            currentState.Activate();
        }
          
        public void OnNextStateRequest(PlayerState _state) 
        {            
            currentState.Diactivate();
            currentState = states.Find(_s => _s.PlayerState == _state);
            currentState.Activate();
        }

        public void GetHit(int _damage) 
        {
            if (currentState.PlayerState == PlayerState.Idle
                || currentState.PlayerState == PlayerState.Fall)
            {
                audioSource.PlayOneShot(getHit);
                currentState.GetHit();
                actualHealth -= _damage;
            }

            CheckHealth(actualHealth);
        }

        public void ReturnToStartPosMinusHealth(Vector3 _startPos)
        {
            transform.position = _startPos;
            actualHealth--;
            CheckHealth(actualHealth);
        }     
        
        public void ReturnToStartPos(Vector3 _startPos)
        {
            transform.position = _startPos;
        }

        void CheckHealth(int _actualHealth) 
        {
            ChangeHealthAction.Invoke(actualHealth);

            if (_actualHealth <= 0)
            {
                currentState.NextStateAction.Invoke(PlayerState.Die);
            }
        }

        void OnTriggerEnter(Collider _trigger)
        {
            if (_trigger.GetComponent<DeathLine>())
            {
                if (actualHealth != 0)
                {
                    PlayerReturnAction.Invoke();
                }
                else
                {
                    PlayerDeathAction.Invoke();
                    currentState.DeathStateAction.Invoke();
                }       
            }
        }
    }
}

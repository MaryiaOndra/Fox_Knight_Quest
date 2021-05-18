using System;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class PlayerController : MonoBehaviour
    {
        public const int MAX_HEALTH = 3;
        int actualHealth;

        List<BaseState> states;
        BaseState currentState;
        StatesPanel statesPanel;
        Collider swordCollider;

        public float PlatformAngle{get;set;}
        public Action PlayerDeathAction;
        public Action<int> PlayerAttack;

        private void OnEnable()
        {
            PlayerDeathAction = currentState.DeathStateAction;
            PlayerAttack = currentState.AttackStateAction;
        }

        private void Awake()
        {
            actualHealth = MAX_HEALTH;

            Animator _playerAnimator = GetComponent<Animator>();
            Rigidbody _rigidbody = GetComponent<Rigidbody>();
            AudioSource _audioSource = GetComponent<AudioSource>();

            statesPanel = FindObjectOfType<StatesPanel>();
            statesPanel.ShowHealth(actualHealth);

            states = new List<BaseState>(GetComponentsInChildren<BaseState>(true));

                states.ForEach(_state =>
                {
                    _state.Setup( _playerAnimator, _rigidbody, _audioSource);
                    _state.NextStateAction = OnNextStateRequest;
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
            if (currentState.PlayerState != PlayerState.Defend)
            {
                currentState.NextStateAction.Invoke(PlayerState.Attacked);
                actualHealth -= _damage;
                statesPanel.ShowHealth(actualHealth);
            }

            CheckHeath(actualHealth);
        }

        void CheckHeath(int _actualHealth) 
        {
            if (_actualHealth <= 0)
            {
                currentState.NextStateAction.Invoke(PlayerState.Die);
            }
        }

        private void OnTriggerEnter(Collider _trigger)
        {
            if (_trigger.GetComponent<DeathLine>())
            {
                PlayerDeathAction.Invoke();
            }
        }
    }
}

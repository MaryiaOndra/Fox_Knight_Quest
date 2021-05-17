using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class PlayerController : MonoBehaviour
    {
        public const int MAX_HEALTH = 3;
        int actualHealth;

        Animator playerAnimator;
        List<BaseState> states;
        BaseState currentState;
        StatesPanel statesPanel;
        Rigidbody rigidbody;

        public float PlatformAngle{get;set;}
        public Action PlayerDeathAction;

        private void OnEnable()
        {
            PlayerDeathAction = currentState.DeathStateAction;
        }

        private void Awake()
        {
            actualHealth = MAX_HEALTH;

            playerAnimator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody>();

            statesPanel = FindObjectOfType<StatesPanel>();
            statesPanel.ShowHealth(actualHealth);

            states = new List<BaseState>(GetComponentsInChildren<BaseState>(true));

                states.ForEach(_state =>
                {
                    _state.Setup( playerAnimator, rigidbody);
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

        public void Attacked(int _attackPower) 
        {
            if (currentState.PlayerState != PlayerState.Defend)
            {
                currentState.NextStateAction.Invoke(PlayerState.Attacked);
                actualHealth -= _attackPower;
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

              //  currentState.NextStateAction.Invoke(PlayerState.Die);
            }
        }
    }
}

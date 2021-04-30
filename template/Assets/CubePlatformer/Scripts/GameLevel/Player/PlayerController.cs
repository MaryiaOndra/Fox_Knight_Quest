using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class PlayerController : MonoBehaviour
    {
          Animator playerAnimator;
        List<BaseState> states;
        BaseState currentState;
        UIController canvasController;
        Rigidbody rigidbody;
        Collider collider;

        public float PlatformAngle{get;set;}
        Action LoseAction;
      
        private void Awake()
        {
            //canvasController = FindObjectOfType<UIController>();
            //canvasController.OnActiveBtn += OnPlayerInput;

            playerAnimator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody>();
            collider = GetComponent<Collider>();

            states = new List<BaseState>(GetComponentsInChildren<BaseState>(true));

                states.ForEach(_state =>
                {
                    _state.Setup(collider, playerAnimator, rigidbody);
                    _state.NextStateAction = OnNextStateRequest;
                });

            currentState = states.Find(_state => _state.PlayerState == PlayerState.Idle);
            currentState.Activate();
        }

        void OnPlayerInput(BtnState _btnState) 
        {
            switch (_btnState)
            {
                case BtnState.MoveForward:
                    currentState.VerticalValue = 1;
                    break;
                case BtnState.MoveRight:
                    currentState.HorizontalValue = 1;
                    break;
                case BtnState.MoveLeft:
                    currentState.HorizontalValue = -1;
                    break;
                case BtnState.MoveBack:
                    currentState.VerticalValue = -1;
                    break;
                case BtnState.Jump:
                    currentState.JumpValue = 1;
                    break;
                case BtnState.Attack:
                    break;
                case BtnState.None:
                    currentState.HorizontalValue = 0;
                    currentState.VerticalValue = 0;
                    currentState.JumpValue = 0;
                    break;
                case BtnState.Slider:
                    currentState.PlatformAngle = PlatformAngle;
                    break;
            }
        }

        public void OnNextStateRequest(PlayerState _state) 
        {            
            currentState.Diactivate();
            currentState = states.Find(_s => _s.PlayerState == _state);
            currentState.Activate();
        }

        public void OnObstacleTriggered() 
        {
            currentState.NextStateAction.Invoke(PlayerState.Die);
            LoseAction.Invoke();
        }
    }
}

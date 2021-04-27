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
        CharacterController chController;
        UIController canvasController;

        public float PlatformAngle{get;set;}
      
        private void Awake()
        {
            canvasController = FindObjectOfType<UIController>();
            canvasController.OnActiveBtn += OnPlayerInput;

            playerAnimator = GetComponent<Animator>();

            states = new List<BaseState>(GetComponentsInChildren<BaseState>(true));
            chController = GetComponent<CharacterController>();

                states.ForEach(_state =>
                {
                    _state.Setup(chController, playerAnimator);
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

        private void OnTriggerEnter(Collider _trigger)
        {
            currentState.OnTrigger(_trigger);
        }
    }
}

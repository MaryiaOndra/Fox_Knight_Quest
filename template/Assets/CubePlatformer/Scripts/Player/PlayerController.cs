using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody rBody;
        Animator playerAnimator;
        Collider playerCollider;
        List<BaseState> states;
        BaseState currentState;
        CharacterController chController;

        public BtnState BtnAction { get; set; }

        private void Awake()
        {
            rBody = GetComponent<Rigidbody>();
            playerAnimator = GetComponent<Animator>();
            playerCollider = GetComponent<Collider>();
            states = new List<BaseState>(GetComponentsInChildren<BaseState>(true));
            chController = GetComponent<CharacterController>();

                states.ForEach(_state =>
                {
                    _state.Setup(chController, playerAnimator, playerCollider, BtnAction);
                    _state.NextStateAction = OnNextStateRequest;
                });

            currentState = states.Find(_state => _state.PlayerState == PlayerState.Idle);
            currentState.Activate();
        }

        public void OnNextStateRequest(PlayerState _state) 
        {
            currentState.Diactivate();
            currentState = states.Find(_s => _s.PlayerState == _state);
            currentState.Activate();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class LevelController : MonoBehaviour
    {
        CharacterController chController;
        UIController uiController;
        BaseState baseState;

        private void Awake()
        {
            chController = GetComponentInChildren<CharacterController>();
            uiController = GetComponentInChildren<UIController>();
            baseState = GetComponentInChildren<BaseState>();
        }

        private void OnEnable()
        {
            uiController.OnDraggedSlider += ChangeState;
            uiController.SliderValue += ChangePlatformAngle;
            uiController.OnActiveBtn += SetPlayerVelocity;
        }
        private void OnDisable()
        {
            uiController.OnDraggedSlider -= ChangeState;
            uiController.SliderValue -= ChangePlatformAngle;
            uiController.OnActiveBtn -= SetPlayerVelocity;
        }

        public void ChangeState(bool _state)
        {
            bool _plContrState = _state == true ? false : true;
            chController.enabled = _plContrState;
        }

        public void ChangePlatformAngle(float _sliderValue)
        {
            transform.rotation = Quaternion.Euler(0, _sliderValue * 360, 0);
        }

        public void SetPlayerVelocity(BtnState _btnState) 
        {
            Vector3 _playerVelocity = new Vector3();

            switch (_btnState)
            {
                case BtnState.MoveForward:
                    _playerVelocity.x = -1;
                    break;
                case BtnState.MoveRight:
                    _playerVelocity.z = 1;
                    break;
                case BtnState.MoveLeft:
                    _playerVelocity.z = -1;
                    break;
                case BtnState.MoveBack:
                    _playerVelocity.x = 1;
                    break;
                case BtnState.Jump:
                    _playerVelocity.y = 1;
                    break;
                case BtnState.Attack:
                    break;
                case BtnState.None:
                    _playerVelocity = Vector3.zero;
                    break;
                default:
                    break;
            }

            baseState.PlayerVelosityTestBase = _playerVelocity;
        }
    }
}

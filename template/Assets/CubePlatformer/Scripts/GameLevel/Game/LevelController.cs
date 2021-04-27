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
        PlayerController playerController;

        float platformAngle;

        List<Coin> coins;
        int totalCount;
        int count;

        private void Awake()
        {
            chController = GetComponentInChildren<CharacterController>();
            uiController = GetComponentInChildren<UIController>();
            playerController = GetComponentInChildren<PlayerController>();

            coins = new List<Coin>(GetComponentsInChildren<Coin>());
            totalCount = coins.Count;
            count = totalCount;
            coins.ForEach(_coin => _coin.OnCoinColected += CheckCoinsAmount);
            uiController.WriteScoreText(coins.Count, totalCount);
        }

        void CheckCoinsAmount() 
        {
            count -= 1;
            uiController.WriteScoreText(count , totalCount);
        }

        private void OnEnable()
        {
            uiController.OnDraggedSlider += ChangeState;
            uiController.SliderValue += ChangePlatformAngle;
        }
        private void OnDisable()
        {
            uiController.OnDraggedSlider -= ChangeState;
            uiController.SliderValue -= ChangePlatformAngle;
        }

        public void ChangeState(bool _state)
        {
            bool _plContrState = _state == true ? false : true;
            chController.enabled = _plContrState;
        }

        public void ChangePlatformAngle(float _sliderValue)
        {
            transform.rotation = Quaternion.Euler(0, _sliderValue * 360, 0);
            platformAngle = transform.rotation.eulerAngles.y;
           
            playerController.PlatformAngle = platformAngle;
            uiController.OnActiveBtn(BtnState.Slider);
        }
    }
}

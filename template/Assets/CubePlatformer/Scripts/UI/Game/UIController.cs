using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class UIController : MonoBehaviour
    {
        public Action<bool> OnDraggedSlider;
        public Action<float> SliderValue;
        public Action<BtnState> OnActiveBtn;

        Slider slider;

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();
            slider.onValueChanged.AddListener(SaveSliderValue);
        }

        public void SliderDragState(bool _state)
        {
            OnDraggedSlider.Invoke(_state);
        }
        void SaveSliderValue(float _value) 
        {
            SliderValue.Invoke(_value);
        }


        public void OnUp()
        {
            OnActiveBtn.Invoke(BtnState.MoveForward);
        }
        public void OnDown()
        {
            OnActiveBtn.Invoke(BtnState.MoveBack);
        }
        public void OnLeft()
        {
            OnActiveBtn.Invoke(BtnState.MoveLeft);
        }
        public void OnRight()
        {
            OnActiveBtn.Invoke(BtnState.MoveRight);
        }
    }
}

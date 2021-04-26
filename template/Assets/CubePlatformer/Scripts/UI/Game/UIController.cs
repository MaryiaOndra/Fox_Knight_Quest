using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class UIController : MonoBehaviour
    {
        public Action<bool> OnDraggedSlider;
        public Action<float> SliderValue;
        public Action<BtnState> OnActiveBtn;

        List<BaseBtn> btnStates;
        Slider slider;

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();
            slider.onValueChanged.AddListener(SaveSliderValue);

            btnStates = new List<BaseBtn>(GetComponentsInChildren<BaseBtn>(true));

            btnStates.ForEach(_state =>
            {
                 _state.BtnAction += SetBtnStateToPlayer;
            });
        }

        public void SliderDragState(bool _state)
        {
            OnDraggedSlider.Invoke(_state);
        }

        void SaveSliderValue(float _value) 
        {
            SliderValue.Invoke(_value);
        }

        public void SetBtnStateToPlayer(BtnState _btnState) 
        {
            OnActiveBtn.Invoke(_btnState);            
        }
    }
}

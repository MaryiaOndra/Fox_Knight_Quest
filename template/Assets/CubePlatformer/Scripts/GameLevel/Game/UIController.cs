using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        TMP_Text scoreTxt;

        List<BaseBtn> btnStates;
        Slider slider;
        KeyboardBtns keyboardBtns;

        public Action<bool> OnDraggedSlider;
        public Action<float> SliderValue;
        public Action<BtnState> OnActiveBtn;

        private void Awake()
        {
            slider = GetComponentInChildren<Slider>();
            slider.onValueChanged.AddListener(SaveSliderValue);

            keyboardBtns = GetComponentInChildren<KeyboardBtns>();
            keyboardBtns.OnKeyboardInput += SetBtnStateToPlayer;

            btnStates = new List<BaseBtn>(GetComponentsInChildren<BaseBtn>(true));

            btnStates.ForEach(_state =>
            {
                 _state.BtnAction += SetBtnStateToPlayer;
            });
        }

        public void WriteScoreText(int _count, int _totalCount) 
        {
            scoreTxt.text = "COINS: " + _count + '/' +_totalCount;
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

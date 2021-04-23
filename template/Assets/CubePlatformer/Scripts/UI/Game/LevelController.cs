using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        Rotator platformRotator;

        [SerializeField]
        CharacterController chController;   
        [SerializeField]
        PlayerController plController;

        Slider slider;
        ScreenSlider screenSlider;

        

        public void AddUIDependency (Slider _slider) 
        {
            slider = _slider;
            screenSlider = slider.GetComponent<ScreenSlider>();
            slider.onValueChanged.AddListener(platformRotator.ChangePlatformAngle);
            screenSlider.OnDragged += ChangeState;          
        }

        public void ChangeState(bool _state)
        {
            bool _plContrState = _state == true ? false : true;
            chController.enabled = _plContrState;
           // plController.enabled = _plContrState;
        }
    }
}

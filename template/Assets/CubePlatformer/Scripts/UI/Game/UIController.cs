using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        Slider screenSlider;
        [SerializeField]
        Button up;
        [SerializeField]
        Button down;
        [SerializeField]
        Button left;
        [SerializeField]
        Button right;

        LevelController levelController;
        ButtonController btnController;

        Action<Action> BtnAction;

        public void SetupUI()
        {
            levelController = FindObjectOfType<LevelController>();
            levelController.AddUIDependency(screenSlider);

            btnController = FindObjectOfType<ButtonController>();
            btnController.OnActiveBtn += SendBtnAction;
        }

        public void SendBtnAction(BtnState _btnAction) 
        {
            levelController.SaveBtnAction(_btnAction);
        }

        private void Update()
        {

        }
    }
}

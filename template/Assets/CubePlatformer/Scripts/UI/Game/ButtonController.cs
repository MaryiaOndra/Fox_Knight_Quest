using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class ButtonController : MonoBehaviour
    {
        Button[] buttons;

        public Action<BtnState> OnActiveBtn;

        private void Awake()
        {
            buttons = gameObject.GetComponentsInChildren<Button>();
        }

        public void CatchBtnSignal(int _btnAction)
        {
            BtnState _action = (BtnState)_btnAction;
            OnActiveBtn.Invoke(_action);
        }
    }
}

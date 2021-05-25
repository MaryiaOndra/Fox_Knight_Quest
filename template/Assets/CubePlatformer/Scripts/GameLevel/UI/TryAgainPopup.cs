using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class TryAgainPopup : BasePopup
    {
        public override Popup ScreenPopup => Popup.TryAgain;

        public Action ReturnMinusHealthAction;
        public Action ReturnAction;

        public void ReturnMinusHealth() 
        {
            ReturnMinusHealthAction.Invoke();
            Hide();
        }

        public void Return() 
        {
            ReturnAction.Invoke();
            Hide();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class ButtonController : MonoBehaviour
    {
        public Action<BtnState> OnActiveBtn;

        public void OnUp() 
        {
            OnActiveBtn.Invoke(BtnState.MoveForward);
        }

        public void OnDown()
        {
            OnActiveBtn.Invoke(BtnState.MoveBack);
        }
    }
}

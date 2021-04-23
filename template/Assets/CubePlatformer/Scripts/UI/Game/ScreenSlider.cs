using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class ScreenSlider : MonoBehaviour
    {
        public Action<bool> OnDragged;

        public void DragState(bool _state) 
        {
            OnDragged.Invoke(_state);
        }
    }
}

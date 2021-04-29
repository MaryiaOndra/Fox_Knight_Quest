using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubePlatformer
{
    abstract public class BaseBtn : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public abstract BtnState ButtonState { get; }

        public Action<BtnState> BtnAction;

        public void OnPointerDown(PointerEventData eventData)
        {
            BtnAction.Invoke(ButtonState);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            BtnAction.Invoke(BtnState.None);
        }        
    }
}

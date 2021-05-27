using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubePlatformer
{
    public class TouchPanel : MonoBehaviour,  IDragHandler, IEndDragHandler
    {
        float dragDelta;

        public Action<float> DragAction;

        public void OnDrag(PointerEventData eventData)
        {
            if (Input.GetMouseButton(1))
            {
                dragDelta = eventData.delta.x;
                DragAction.Invoke(dragDelta);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            dragDelta = 0;
            DragAction.Invoke(dragDelta);
        }
    }
}

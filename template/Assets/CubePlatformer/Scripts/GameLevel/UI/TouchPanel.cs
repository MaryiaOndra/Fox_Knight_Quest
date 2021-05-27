using System;
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
            dragDelta = eventData.delta.x;
            DragAction.Invoke(dragDelta);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            dragDelta = 0;
            DragAction.Invoke(dragDelta);
        }
    }
}

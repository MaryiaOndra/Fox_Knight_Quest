using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubePlatformer
{
    public class TouchPanel : MonoBehaviour,  IDragHandler, IEndDragHandler
    {
        public float DragDelta { get; private set; }

        public void OnDrag(PointerEventData eventData)
        {
            DragDelta = eventData.delta.x;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            DragDelta = 0;
        }
    }
}

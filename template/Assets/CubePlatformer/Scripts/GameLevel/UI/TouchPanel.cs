using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubePlatformer
{
    public class TouchPanel : MonoBehaviour,  IDragHandler, IEndDragHandler
    {
        float dragDelta;

        CameraRotator cameraRotator;

        private void OnEnable()
        {
            cameraRotator = FindObjectOfType<CameraRotator>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (Input.GetMouseButton(1))
            {
                dragDelta = eventData.delta.x;
                cameraRotator.DragDelta = dragDelta;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            dragDelta = 0;
            cameraRotator.DragDelta = dragDelta;
        }
    }
}

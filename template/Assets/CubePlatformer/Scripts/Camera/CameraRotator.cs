using System;
using UnityEngine;

namespace CubePlatformer
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField]
        Transform targetTr;

        [SerializeField]
        float speed;

        Vector3 eulerAngles;
        float prevYPos = 0;

        public Action<float> DragDelta;

        private void OnEnable()
        {
            DragDelta = RotateCamera;
        }

        void Update()
        {
            transform.position = targetTr.position;
        }

        void RotateCamera(float _dragDelta) 
        {
            float _yPos = _dragDelta;

            if (_yPos != prevYPos)
            {
                eulerAngles += new Vector3(0f, _yPos, 0f) * speed;
                transform.eulerAngles = eulerAngles;
            }
            prevYPos = _yPos;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
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

        public float DragDelta { get; set; }

        void Update()
        {
            transform.position = targetTr.position;

            float _yPos = DragDelta;

            if (_yPos != prevYPos)
            {
                eulerAngles += new Vector3(0f, _yPos, 0f) * speed;
                transform.eulerAngles = eulerAngles;
            }
            prevYPos = _yPos;
        }
    }
}

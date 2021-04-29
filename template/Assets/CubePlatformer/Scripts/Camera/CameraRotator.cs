using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField]
        float speed;

        TouchPanel touchPanel;
        Vector3 eulerAngles;
        float prevYPos = 0;

        public Action changeCamLocationAction; 

        private void OnEnable()
        {
            touchPanel = FindObjectOfType<TouchPanel>();
        }

        void Update()
        {
            float _yPos = touchPanel.DragDelta;

            if (_yPos != prevYPos)
            {
                eulerAngles += new Vector3(0f, _yPos, 0f) * speed;
                transform.eulerAngles = eulerAngles;
            }
            prevYPos = _yPos;
        }
    }
}

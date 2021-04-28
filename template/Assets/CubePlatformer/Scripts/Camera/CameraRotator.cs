using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField]
        TouchPanel touchPanel;
        [SerializeField]
        float speed;

        Vector3 eulerAngles;
        float prevYPos = 0;

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

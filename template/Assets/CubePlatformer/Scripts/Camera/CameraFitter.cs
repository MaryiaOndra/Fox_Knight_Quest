using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubePlatformer
{
    [ExecuteAlways]
    public class CameraFitter : MonoBehaviour
    {
        const int CAMERA_WIDTH = 7;

        Camera fitCamera;

        void OnEnable()
        {
            fitCamera = GetComponent<Camera>();
        }

        void Update()
        {
            fitCamera.orthographicSize = (float)Screen.height / Screen.width * CAMERA_WIDTH;
        }
    }
}

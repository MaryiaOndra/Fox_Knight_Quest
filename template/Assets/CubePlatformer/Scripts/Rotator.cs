using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Rotator : MonoBehaviour
    {
        float prevValue;
        float sliderValue;

        Vector3 eulers = new Vector3();


        private void Awake()
        {

        }

        public void ChangePlatformAngle(float _sliderValue)
        {

            transform.rotation = Quaternion.Euler(0, _sliderValue * 360, 0);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Cloud : MonoBehaviour
    {
        [SerializeField]
        float cloudsLenght = 45f;
        public float Length => cloudsLenght;

        public float Position 
        {
            get => transform.localPosition.z;
            set 
            {
                var _pos = transform.localPosition;
                _pos.z = value;
                transform.localPosition = _pos;         
            }
        }
    }
}

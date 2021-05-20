using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Clouds : MonoBehaviour
    {
        [SerializeField]
        MeshRenderer skyMesh;

        [SerializeField]
        float cloudsLenght = 45f;
        public float Length => cloudsLenght;

        MeshRenderer[] cloudsMeshes;

        private void Awake()
        {
            cloudsMeshes = GetComponentsInChildren<MeshRenderer>();

            if (skyMesh == null)
               return;

            foreach (var _cloud in cloudsMeshes)
            {
                _cloud.sharedMaterial = skyMesh.material;
            }            
        }

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

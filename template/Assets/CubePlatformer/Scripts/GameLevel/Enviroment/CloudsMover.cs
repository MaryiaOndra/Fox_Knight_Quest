using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class CloudsMover : MonoBehaviour
    {
        [SerializeField]
        float speed = 1;

        List<Clouds> clouds;

        private void Awake()
        {
            clouds = new List<Clouds>(GetComponentsInChildren<Clouds>());
        }

        void Update()
        {
            for (int i = 0; i < clouds.Count; i++)
            {
                var _cloud = clouds[i];
                _cloud.Position += speed * Time.deltaTime;

                if (_cloud.Position >= _cloud.Length)
                {
                    var _lastCloud = clouds[clouds.Count - 1];

                    _cloud.Position = _lastCloud.Position - _cloud.Length;

                    clouds.RemoveAt(i);
                    clouds.Add(_cloud);

                    i--;
                }

            }
        }
    }
}

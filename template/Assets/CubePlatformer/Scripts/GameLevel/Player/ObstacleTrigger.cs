using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CubePlatformer
{
    public class ObstacleTrigger : MonoBehaviour
    {
        [SerializeField]
        UnityEvent ObstacleTriggerEvent;

        private void OnTriggerEnter(Collider _collider)
        {
            ObstacleTriggerEvent.Invoke();
        }

    }
}

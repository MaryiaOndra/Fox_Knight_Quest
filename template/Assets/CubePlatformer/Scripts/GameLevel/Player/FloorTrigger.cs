using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class FloorTrigger : MonoBehaviour
    {
        public bool IsGrounded { get; private set; }

        private void OnTriggerStay(Collider _collider)
        {
             IsGrounded = true;
        }

        private void OnTriggerExit(Collider _collider)
        {
            IsGrounded = false;
        }
    }
}

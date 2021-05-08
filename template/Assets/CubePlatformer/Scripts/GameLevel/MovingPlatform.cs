using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class MovingPlatform : MonoBehaviour
    {
        private void OnCollisionEnter(Collision _collision)
        {
            if (_collision.gameObject.GetComponent<PlayerController>())
            {
                _collision.gameObject.transform.SetParent(transform);
            }
        }

        private void OnCollisionExit(Collision _collision)
        {
            if (_collision.gameObject.GetComponent<PlayerController>())
            {
                _collision.gameObject.transform.SetParent(null);
            }
        }
    }
}

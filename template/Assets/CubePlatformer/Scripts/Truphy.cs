using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Truphy : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>())
            {
                Destroy(gameObject);
            }
        }
    }
}

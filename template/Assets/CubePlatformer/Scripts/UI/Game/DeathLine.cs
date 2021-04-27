using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class DeathLine : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {         
            if (other.GetComponent<PlayerController>())
            {
                Debug.Log("DEAD ZONE");
            }
        }
    }
}

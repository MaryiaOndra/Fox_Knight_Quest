using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Coin : MonoBehaviour
    {
        public Action OnCoinColected;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>())
            {
                Destroy(gameObject);
                OnCoinColected.Invoke();               
            }
        }
    }
}

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
            //OnCoinColected.Invoke();
            Destroy(gameObject);
        }
    }
}

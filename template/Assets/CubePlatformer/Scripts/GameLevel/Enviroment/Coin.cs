using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Coin : MonoBehaviour
    {
        public Action<Coin> OnCoinColected;

        AudioSource audioSource;

        public AudioClip CoinClip { get; private set; }

        private void Awake()
        {
            CoinClip = GetComponent<AudioSource>().clip;
        }

        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
            OnCoinColected.Invoke(this);
        }
    }
}

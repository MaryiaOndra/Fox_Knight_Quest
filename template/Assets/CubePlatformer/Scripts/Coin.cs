using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Coin : MonoBehaviour
    {
        public Action OnCoinColected;

        AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            OnCoinColected.Invoke();
            audioSource.PlayOneShot(audioSource.clip);
            gameObject.SetActive(false);
           // Destroy(gameObject, audioSource.clip.length);           
        }
    }
}

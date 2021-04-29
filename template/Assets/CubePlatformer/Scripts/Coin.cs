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
            SoundMgr.Instance.PlaySound(audioSource.clip);
            Destroy(gameObject, audioSource.clip.length);           
        }
    }
}

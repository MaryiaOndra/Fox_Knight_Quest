using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    [RequireComponent(typeof(AudioSource))]
    public class Nameplate : MonoBehaviour
    {
        [SerializeField]
        NameplatesConfigs nameplateConfigs;
        [SerializeField]
        GameObject exlamation;

        AudioSource audioSource;
        bool firstTime = true;

        public Action<string> ActivateNameplate;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (firstTime)
            {
                exlamation.SetActive(false);
                audioSource.PlayOneShot(audioSource.clip);
                ActivateNameplate.Invoke(nameplateConfigs.Frase);
                firstTime = false;
            }
        }
    }
}

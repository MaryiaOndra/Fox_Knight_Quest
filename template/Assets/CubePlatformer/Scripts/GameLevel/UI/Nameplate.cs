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

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (firstTime)
            {
                exlamation.SetActive(false);
                audioSource.PlayOneShot(nameplateConfigs.Clip);
                ActivateNameplate.Invoke(nameplateConfigs.Frase);
                firstTime = false;
            }
        }
    }
}

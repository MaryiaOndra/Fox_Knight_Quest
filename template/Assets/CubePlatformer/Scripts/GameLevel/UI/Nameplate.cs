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

        protected NameplatesConfigs Configs => nameplateConfigs; 

        protected virtual void InvokeNameplate(string _frase) 
        {
            ActivateNameplate.Invoke(_frase);
        }

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void OnMouseDown()
        {
            if (firstTime)
            {
                exlamation.SetActive(false);
                firstTime = false;
            }

            audioSource.PlayOneShot(audioSource.clip);

            InvokeNameplate(nameplateConfigs.Frase);
        }
    }
}

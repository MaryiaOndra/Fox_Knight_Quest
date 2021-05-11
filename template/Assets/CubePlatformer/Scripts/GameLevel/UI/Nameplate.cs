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


        protected virtual void InvokeNameplate(string _frase) 
        {
            ActivateNameplate.Invoke(_frase);
        }

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        protected virtual void OnMouseDown()
        {
            if (firstTime)
            {
                exlamation.SetActive(false);
                firstTime = false;
            }

            audioSource.PlayOneShot(audioSource.clip);

            InvokeNameplate(nameplateConfigs.Frase);
        }

        //void OnTriggerEnter(Collider other)
        //{
        //    if (firstTime)
        //    {
        //        exlamation.SetActive(false);
        //        audioSource.PlayOneShot(audioSource.clip);
        //        ActivateNameplate.Invoke(nameplateConfigs.Frase);
        //        firstTime = false;
        //    }
        //}



    }
}

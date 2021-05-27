using CubePlatformer.Base;
using System;
using UnityEngine;

namespace CubePlatformer
{
    [RequireComponent(typeof(AudioSource))]
    public class Nameplate : MonoBehaviour
    {
        protected static readonly string SIGHT_TO_REPLACE = "#";

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
            string _frase = nameplateConfigs.Frase;

            if (firstTime)
            {
                exlamation.SetActive(false);
                firstTime = false;
            }

            audioSource.PlayOneShot(audioSource.clip);

            if (_frase.Contains(SIGHT_TO_REPLACE))
            {
                int _coinsAmount = GameInfo.Instance.LevelConfig.CoinsAmount;
                _frase = Configs.Frase.Replace(SIGHT_TO_REPLACE, _coinsAmount.ToString());
            }

            InvokeNameplate(_frase);
        }
    }
}

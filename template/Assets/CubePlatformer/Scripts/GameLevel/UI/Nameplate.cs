using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    [RequireComponent(typeof(AudioSource))]
    public class Nameplate : MonoBehaviour
    {
        protected static readonly int IS_ENTER = Animator.StringToHash("IsEnter");
        //const string FRASE = "You should collect 3 coins to finish this level!";

        [SerializeField]
        NameplatesConfigs nameplateConfigs;

        [SerializeField]
        TMP_Text text;

        Animator animator;
        AudioSource audioSource;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            audioSource = GetComponent<AudioSource>();
            text.text = nameplateConfigs.Frase;
        }

        private void OnTriggerEnter(Collider other)
        {
            animator.SetBool(IS_ENTER, true);
            audioSource.PlayOneShot(nameplateConfigs.Clip);
        }

        private void OnTriggerExit(Collider other)
        {
            animator.SetBool(IS_ENTER, false);
        }
    }
}

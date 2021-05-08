using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    public class Nameplate : MonoBehaviour
    {
        protected static readonly int IS_ENTER = Animator.StringToHash("IsEnter");
        const string FRASE = "You should collect 3 coins to finish this level!";

        [SerializeField]
        TMP_Text text;

        Animator animator;

        private void Awake()
        {
           animator = GetComponentInChildren<Animator>();
            text.text = FRASE;
        }

        private void OnTriggerEnter(Collider other)
        {
            animator.SetBool(IS_ENTER, true);
        }

        private void OnTriggerExit(Collider other)
        {
            animator.SetBool(IS_ENTER, false);
        }
    }
}

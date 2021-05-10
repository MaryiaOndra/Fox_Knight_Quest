using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    public class NotesPanel : MonoBehaviour
    {
        static readonly int IS_ACTIVE = Animator.StringToHash("IsActive");

        TMP_Text noteText;
        Animator animator;

        private void Awake()
        {
            noteText = GetComponentInChildren<TMP_Text>();
            animator = GetComponent<Animator>();
        }

        public void ShowPanel(string _text) 
        {
            Time.timeScale = 0;
            noteText.text = _text;
            animator.SetBool(IS_ACTIVE, true);
        }

        public void HidePanel() 
        {
            Time.timeScale = 1;
            animator.SetBool(IS_ACTIVE, false);
        }
    }
}

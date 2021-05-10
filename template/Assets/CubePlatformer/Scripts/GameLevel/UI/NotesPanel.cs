using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    public class NotesPanel : MonoBehaviour
    {
        //static readonly int SHOW = Animator.StringToHash("Show");
        //static readonly int HIDE = Animator.StringToHash("Hide");
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
            noteText.text = _text;
            animator.SetBool(IS_ACTIVE, true);
        }

        public void HidePanel() 
        {
            animator.SetBool(IS_ACTIVE, false);
        }
    }
}

using System;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    public class NotesPanel : MonoBehaviour
    {
        static readonly int IS_ACTIVE = Animator.StringToHash("IsActive");

        public Action<string> ShowPanel;

        TMP_Text noteText;
        Animator animator;

        private void OnEnable()
        {
            ShowPanel = AddTextToPanel;
        }

        private void Awake()
        {
            noteText = GetComponentInChildren<TMP_Text>();
            animator = GetComponent<Animator>();
        }

        void AddTextToPanel(string _text) 
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

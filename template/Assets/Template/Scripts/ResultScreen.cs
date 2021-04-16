using System.Collections;
using System.Collections.Generic;
using Template.Base;
using Template.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template
{
    public class ResultScreen : BaseScreen
    {
        public const string Exit_Menu = "Exit_Menu";
        public const string Exit_Replay = "Exit_Replay";

        [SerializeField]
        TextMeshProUGUI scoreText;

        public override void Show()
        {
            base.Show();
            scoreText.text = GameInfo.Instance.Score.ToString();
        }

        public void OnRestartPressed() 
        {
            Exit(Exit_Replay);    
        }

        public void OnMenuPressed() 
        {
            Exit(Exit_Menu);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Template.Base;
using Template.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template
{
    public class MenuScreen : BaseScreen
    {
        public const string Exit_Settings = "Exit_Settings";
        public const string Exit_Game = "Exit_Game";

        [SerializeField]
        TextMeshProUGUI scoreText;

        public override void Show()
        {
            base.Show();
            scoreText.text = GameInfo.Instance.Score.ToString();
        }

        public void OnSettingsPressed() 
        {
            Exit(Exit_Settings);
        }

        public void OnGamePressed()
        {
            Exit(Exit_Game);
        }
    }
}

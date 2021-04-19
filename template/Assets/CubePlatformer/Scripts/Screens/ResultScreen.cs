using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Base;
using CubePlatformer.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class ResultScreen : BaseScreen
    {
        public const string Exit_Game = "Exit_Game";
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

        public void OnGamePressed() 
        {
            Exit(Exit_Game);
        }
    }
}

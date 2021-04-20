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
        public const string Exit_NextLvl = "Exit_NextLvl";
        public const string Exit_Replay = "Exit_Replay";

        [SerializeField]
        TextMeshProUGUI scoreText;

        public override void Show()
        {
            base.Show();
            scoreText.text = GameInfo.Instance.Scores.ToString();
        }

        public void OnRestartPressed() 
        {
            Exit(Exit_Replay);    
        }

        public void OnNextLvlPressed() 
        {
            Exit(Exit_NextLvl);
        }
    }
}

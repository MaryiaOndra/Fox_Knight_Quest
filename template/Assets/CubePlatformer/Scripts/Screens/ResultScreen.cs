using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Base;
using CubePlatformer.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class ResultScreen : BaseScreen
    {
        public const string Exit_NextLvl = "Exit_NextLvl";
        public const string Exit_Replay = "Exit_Replay";

        [SerializeField]
        TextMeshProUGUI scoreText;
        [SerializeField]
        Button NextLvlBtn;

        public override void Show()
        {
            base.Show();
            Time.timeScale = 0;

            int _actualScore = GameInfo.Instance.LevelResultInfo.Scores;
            int _expectedScore = GameInfo.Instance.LevelConfig.CoinsAmount;
            ActivateNextLvlBtn(_actualScore, _expectedScore);
            scoreText.text = _actualScore + " / " + _expectedScore;
        }

        void ActivateNextLvlBtn(int _actualScore, int _expectedScore)
        {
            NextLvlBtn.interactable = _actualScore == _expectedScore ? true : false;
        }

        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            Exit(Exit_Replay);
        }

        public void OnNextLvlPressed()
        {
            Time.timeScale = 1;
            GameInfo.Instance.LevelIndex += 1;
            Exit(Exit_NextLvl);
        }
    }
}

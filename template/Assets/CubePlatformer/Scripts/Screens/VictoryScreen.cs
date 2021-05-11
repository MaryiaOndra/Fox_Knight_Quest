using CubePlatformer.Base;
using CubePlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    public class VictoryScreen : BaseScreen
    {
        public const string Exit_NextLvl = "Exit_NextLvl";

        [SerializeField]
        TextMeshProUGUI scoreText;

        int actualScore;
        int expectedScore;

        public override void Show()
        {
            base.Show();
            Time.timeScale = 0;

            actualScore = GameInfo.Instance.LevelResultInfo.Scores;
            expectedScore = GameInfo.Instance.LevelConfig.CoinsAmount;

            WriteScore(actualScore, expectedScore);
        }

        public void OnNextLvlPressed()
        {
            Time.timeScale = 1;
            GameInfo.Instance.LevelIndex += 1;
            Exit(Exit_NextLvl);
        }

        void WriteScore(int _actualScore, int _expectedScore)
        {
            scoreText.text = _actualScore + " / " + _expectedScore;
        }
    }
}

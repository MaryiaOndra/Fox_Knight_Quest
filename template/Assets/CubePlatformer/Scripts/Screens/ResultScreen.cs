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
        public const string WinLabel = "VICTORY!";
        public const string LoseLabel = "DEFEAT!";

        [SerializeField]
        TextMeshProUGUI resultLabel;
        [SerializeField]
        TextMeshProUGUI scoreText;
        [SerializeField]
        Button NextLvlBtn;        
        [SerializeField]
        Button ReplayBtn;

        int actualScore;
        int expectedScore;

        private void OnEnable()
        {
            NextLvlBtn.gameObject.SetActive(false);
            ReplayBtn.gameObject.SetActive(false);
        }

        public override void Show()
        {
            base.Show();
            Time.timeScale = 0;

            actualScore = GameInfo.Instance.LevelResultInfo.Scores;
            expectedScore = GameInfo.Instance.LevelConfig.CoinsAmount;

            WriteScore(actualScore, expectedScore);
            CheckWinState(actualScore, expectedScore);
        }

        void WriteScore(int _actualScore, int _expectedScore) 
        {
            scoreText.text = _actualScore + " / " + _expectedScore;
        }

        void CheckWinState(int _actualScore, int _expectedScore)
        {
            bool _isWon = _actualScore == _expectedScore ? true : false;

            if (_isWon)
            {
                NextLvlBtn.gameObject.SetActive(_isWon);
                ReplayBtn.gameObject.SetActive(!_isWon);
                resultLabel.text = WinLabel;

            }
            else 
            {
                NextLvlBtn.gameObject.SetActive(_isWon);
                ReplayBtn.gameObject.SetActive(!_isWon);
                resultLabel.text = LoseLabel;
            }
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

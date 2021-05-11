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
    public class LooseScreen : BaseScreen
    {
        public const string Exit_Replay = "Exit_Replay";
       
        public override void Show()
        {
            base.Show();
            Time.timeScale = 0;

            //actualScore = GameInfo.Instance.LevelResultInfo.Scores;
            //expectedScore = GameInfo.Instance.LevelConfig.CoinsAmount;

            //WriteScore(actualScore, expectedScore);
            //CheckWinState(actualScore, expectedScore);
        }

        //void WriteScore(int _actualScore, int _expectedScore) 
        //{
        //    scoreText.text = _actualScore + " / " + _expectedScore;
        //}

        //void CheckWinState(int _actualScore, int _expectedScore)
        //{
        //    bool _isWinScore = _actualScore == _expectedScore ? true : false;
        //    bool _isComeThroughPortal = GameInfo.Instance.LevelConfig.IsGoingThoughPortal;

        //    bool _isNextLvl = _isWinScore && _isComeThroughPortal ? true : false;

        //    if (_isNextLvl)
        //    {
        //        NextLvlBtn.gameObject.SetActive(true);
        //        ReplayBtn.gameObject.SetActive(false);
        //        resultLabel.text = WinLabel;

        //    }
        //    else 
        //    {
        //        NextLvlBtn.gameObject.SetActive(false);
        //        ReplayBtn.gameObject.SetActive(true);
        //        resultLabel.text = LoseLabel;
        //    }
        //}

        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            Exit(Exit_Replay);
        }
    }
}

using CubePlatformer.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    public class VictoryPopUp : BasePopup
    {
        [SerializeField]
        TextMeshProUGUI scoreText;

        public override Popup ScreenPopup => Popup.Victory;

        int actualScore;
        int expectedScore;

        public Action NextLevelAction;

        public override void Show()
        {
            base.Show();

            actualScore = GameInfo.Instance.LevelResultInfo.Scores;
            expectedScore = GameInfo.Instance.LevelConfig.CoinsAmount;
            WriteScore(actualScore, expectedScore);
        }

        void WriteScore(int _actualScore, int _expectedScore)
        {
            scoreText.text = _actualScore + " / " + _expectedScore;
        }

        public void GoToNextLevel() 
        {
            NextLevelAction.Invoke();
            Hide();
        }
    }
}

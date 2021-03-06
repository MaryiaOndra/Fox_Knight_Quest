using CubePlatformer.Base;
using System;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    public class VictoryPopUp : BasePopup
    {
        [SerializeField]
        TextMeshProUGUI scoreText;     
        [SerializeField]
        TextMeshProUGUI timeText;

        public override Popup ScreenPopup => Popup.Victory;

        public Action NextLevelAction;

        public override void Show()
        {
            base.Show();

            var _actualScore = GameInfo.Instance.LevelResultInfo.Scores;
            var _expectedScore = GameInfo.Instance.LevelConfig.CoinsAmount;
            var _time = GameInfo.Instance.LevelResultInfo.Time;
            WriteScore(_actualScore, _expectedScore, _time);
        }

        void WriteScore(int _actualScore, int _expectedScore, float _time)
        {
            scoreText.text = _actualScore + " / " + _expectedScore;
            timeText.text = GameInfo.Instance.ConvertTime(_time);
        }

        public void GoToNextLevel() 
        {
            NextLevelAction.Invoke();
            Hide();
        }
    }
}

using CubePlatformer.Base;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    public class Timer : MonoBehaviour
    {
        TMP_Text timerText;
        float timeToDisplay;

        public bool isTimerActive;

        private void OnEnable()
        {
            timerText = GetComponentInChildren<TMP_Text>(true);
            timeToDisplay = -0.1f;
        }

        private void Update()
        {
            timeToDisplay += Time.deltaTime;
            DisplayTime(timeToDisplay);
            GameInfo.Instance.Time = timeToDisplay;
        }

        void DisplayTime(float _timeToDisplay)
        {
            _timeToDisplay += 1;

            float minutes = Mathf.FloorToInt(_timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(_timeToDisplay % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}

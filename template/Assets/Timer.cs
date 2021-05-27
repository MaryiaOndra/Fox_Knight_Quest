using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    public class Timer : MonoBehaviour
    {
        private TMP_Text timerText;
        private float timeToDisplay;

        public bool isTimerActive;

        private void OnEnable()
        {
            timerText = GetComponentInChildren<TMP_Text>(true);
        }

        private void Update()
        {
            if (isTimerActive)
            {
                timeToDisplay = Time.time;
            }
            else 
            {
                timeToDisplay = 0;
            }

            DisplayTime(timeToDisplay);
        }

        void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        void ReloadTimer() 
        {
            DisplayTime(0);
        }
    }
}

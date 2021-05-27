using CubePlatformer.Base;
using System;
using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    public class StatesPanel : MonoBehaviour
    {
        [SerializeField]
        TMP_Text scoreTxt;

        [SerializeField]
        TMP_Text healthTxt;

        Timer timer;

        public Action<float> StartTimer;
        public Action<float> StopTimer;

        void Awake() 
        {
            timer = GetComponentInChildren<Timer>(true);

        }

        public void TimerOn() 
        {
            timer.isTimerActive = true;
        }

        public void TimerOff() 
        {
            timer.isTimerActive = false;
        }

        public void ShowScores(int _score) 
        {
            scoreTxt.text = "x "+ _score.ToString();
        }

        public void ShowHealth(int _health) 
        {
            healthTxt.text = "x " + _health.ToString();
        }
    }
}

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

        void Awake() 
        {
            Debug.Log("Awake: " + name);
            timer = GetComponentInChildren<Timer>(true);
        }

        public void TimerOn() 
        {
            Debug.Log("TimerON");
            timer.gameObject.SetActive(true);
        }

        public void TimerOff() 
        {
            Debug.Log("TimerOFF");
            timer.gameObject.SetActive(false);
        }

        public void ShowScores(int _score) 
        {
            scoreTxt.text = "x "+ _score.ToString();
        }

        public void ShowHealth(int _health) 
        {
            Debug.Log("ShowHealth: " + _health);
            healthTxt.text = "x " + _health.ToString();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class StatesPanel : MonoBehaviour
    {
        [SerializeField]
        TMP_Text scoreTxt;
        [SerializeField]
        TMP_Text healthTxt;

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

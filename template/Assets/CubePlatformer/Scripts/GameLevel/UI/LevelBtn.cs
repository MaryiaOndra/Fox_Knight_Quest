using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class LevelBtn : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI levelText;

        Button levelBtn;
        int levelIndex;

        public Action<int> LevelPressed { get; set; }

        void Awake()
        {
            levelBtn = GetComponent<Button>();
        }

        public void Setup(int _levelIndex, LevelState _levelState)
        {
            levelIndex = _levelIndex;
            levelText.text = (_levelIndex + 1).ToString();

            levelBtn.interactable = _levelState == LevelState.Unlocked;
        }

        public void OnBtnPressed()
        {
            LevelPressed.Invoke(levelIndex);
        }
    }
}

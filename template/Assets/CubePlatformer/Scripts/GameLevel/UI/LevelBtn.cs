using CubePlatformer.Base;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class LevelBtn : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI levelText;     
        
        [SerializeField]
        TextMeshProUGUI timeText;

        Button levelBtn;
        int levelIndex;

        public Action<int> LevelPressed { get; set; }

        void Awake()
        {
            levelBtn = GetComponent<Button>();
        }

        public void Setup(int _levelIndex, LevelState _levelState)
        {
            levelBtn.interactable = _levelState == LevelState.Unlocked;
            levelIndex = _levelIndex;
            levelText.text = levelBtn.interactable ? (_levelIndex + 1).ToString() : string.Empty;
        }

        public void OnBtnPressed()
        {
            LevelPressed.Invoke(levelIndex);
        }
    }
}

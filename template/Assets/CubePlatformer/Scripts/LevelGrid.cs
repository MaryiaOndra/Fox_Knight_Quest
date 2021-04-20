using CubePlatformer.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class LevelGrid : MonoBehaviour
    {
        [SerializeField]
        GameObject levelBtnPrefab;

        public Action<int> LevelSelected { get; set; }

        public void ShowLevels(List<EachLevelConfigs> _levelConfigs, List<LevelState> _levelsStates) 
        {
            for (int i = 0; i < _levelConfigs.Count; i++)
            {
                var _levelBtn = Instantiate(levelBtnPrefab, transform).GetComponent<LevelBtn>();
                _levelBtn.Setup(i, _levelsStates[i]);
                _levelBtn.LevelPressed += OnLevelSelected;
            }
        }

        void OnLevelSelected(int _levelIndex) 
        {
            LevelSelected.Invoke(_levelIndex);
        }
    }
}

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

        List<RectTransform> buttons = new List<RectTransform>();
        public Action<int> LevelSelected { get; set; }

        public void ShowLevels(List<EachLevelConfigs> _levelConfigs, List<LevelState> _levelsStates) 
        {
            if (!gameObject.GetComponentInChildren<LevelBtn>()) 
            {
                for (int i = 0; i < _levelConfigs.Count; i++)
                {
                    var _btnObj = Instantiate(levelBtnPrefab, transform, false);
                    buttons.Add(_btnObj.GetComponent<RectTransform>());

                    var _levelBtn = _btnObj.GetComponent<LevelBtn>();
                    _levelBtn.Setup(i, _levelsStates[i]);
                    _levelBtn.LevelPressed += OnLevelSelected;
                }
            }             
        }

        void OnLevelSelected(int _levelIndex) 
        {
            LevelSelected.Invoke(_levelIndex);
        }
    }
}

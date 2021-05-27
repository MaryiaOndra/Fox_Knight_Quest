using System;
using System.Collections.Generic;
using UnityEngine;

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
                for (int i = 0; i < _levelConfigs.Count; i++)
                {
                    var _btnObj = Instantiate(levelBtnPrefab, transform, false);
                    buttons.Add(_btnObj.GetComponent<RectTransform>());

                    var _levelBtn = _btnObj.GetComponent<LevelBtn>();
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

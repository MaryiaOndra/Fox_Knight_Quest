using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Base;
using CubePlatformer.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class MenuScreen : BaseScreen
    {
        [SerializeField]
        LevelGrid levelGrid;

        public const string Exit_Settings = "Exit_Settings";
        public const string Exit_Game = "Exit_Game";

        public override void Show()
        {
            base.Show();

            levelGrid.LevelSelected += OnLevelSelected;

            var _levelsStates = new List<LevelState>();

            int _levelsCount = GameInfo.Instance.EachLevelConfigs.Count;

            for (int i = 0; i < _levelsCount; i++)
            {
                var _levelState = GameInfo.Instance.GetLevelState(i);

                if (_levelState == LevelState.NeedUnlock)
                {
                    _levelState = LevelState.Unlocked;
                    GameInfo.Instance.SetLevelState(i, _levelState);
                }

                _levelsStates.Add(_levelState);
            }

            levelGrid.ShowLevels(GameInfo.Instance.EachLevelConfigs, _levelsStates);
        }

        void OnLevelSelected(int _levelIndex)
        {
            GameInfo.Instance.LevelIndex = _levelIndex;
            Exit(Exit_Game);
        }

        public void OnSettingsPressed() 
        {
            Debug.Log(name + "OnSettingsPressed");
            Exit(Exit_Settings);
        }

        public void OnGamePressed()
        {
            Debug.Log(name + "OnGamePressed");
            Exit(Exit_Game);
        }
    }
}

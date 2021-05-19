using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Base;
using CubePlatformer.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class LevelsScreen : BaseScreen
    {
        [SerializeField]
        LevelGrid levelGrid;
        [SerializeField]
        TMP_Text LevelsScores;

        public const string Exit_Settings = "Exit_Settings";
        public const string Exit_Game = "Exit_Game";
        public const string Exit_Menu = "Exit_Menu";

        private void Awake()
        {
            levelGrid.LevelSelected = OnLevelSelected;

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

            LevelsScores.text = GameInfo.Instance.Scores.ToString();
        }


        void OnLevelSelected(int _levelIndex)
        {
            GameInfo.Instance.LevelIndex = _levelIndex;
            SoundMgr.Instance.PlayBtnSound();

            Exit(Exit_Game);
        }

        public void OnSettingsPressed() 
        {
            SoundMgr.Instance.PlayBtnSound();

            Exit(Exit_Settings);
        }

        public void OnMenuPressed() 
        {
            SoundMgr.Instance.PlayBtnSound();

            Exit(Exit_Menu);
        }

    }
}

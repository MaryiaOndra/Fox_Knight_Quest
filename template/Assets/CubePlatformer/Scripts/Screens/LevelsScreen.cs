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
        }

        public override void Show()
        {
            base.Show();

            SoundMgr.Instance.PlayMusic();
        }

        void OnLevelSelected(int _levelIndex)
        {
            GameInfo.Instance.LevelIndex = _levelIndex;
            Exit(Exit_Game);
            SoundMgr.Instance.PlayBtnSound();
        }

        public void OnSettingsPressed() 
        {
            Exit(Exit_Settings);
            SoundMgr.Instance.PlayBtnSound();
        }

        public void OnMenuPressed() 
        {
            Exit(Exit_Menu);
            SoundMgr.Instance.PlayBtnSound();
        }

    }
}

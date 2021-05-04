using System;
using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer.Base
{
    public class GameInfo : BaseManager<GameInfo>
    {
        [SerializeField]
        LevelsConfigs levelsConfigs;

        public int LevelIndex { get; set; }
        public List<EachLevelConfigs> EachLevelConfigs => levelsConfigs.EachLevelConfigs;
        public EachLevelConfigs LevelConfig => EachLevelConfigs[LevelIndex];
        public LevelResultInfo LevelResultInfo { get; private set; }

        public void Setup() 
        {
            if (GetLevelState(0) == LevelState.Locked)
            {
                PlayerPrefs.DeleteAll();
                SetLevelState(0, LevelState.Unlocked);                            
;           }
        }

        public LevelState GetLevelState(int _levelIndex)
        {
            int _levelIntState = PlayerPrefs.GetInt(PrefsKeys.Level_ + _levelIndex);
            return (LevelState)_levelIntState;
        }

        public void SetLevelState(int _levelIndex, LevelState _levelState) 
        {
            PlayerPrefs.SetInt(PrefsKeys.Level_ + _levelIndex, (int)_levelState);
        }

        public int Scores { get;set; }
        //public int Scores
        //{
        //    get => PlayerPrefs.GetInt(PrefsKeys.Scores);
        //    set => PlayerPrefs.SetInt(PrefsKeys.Scores, value);
        //}

        public void RegisterResult(int _collectedCoins) 
        {
           // LevelResultInfo = new LevelResultInfo();
            //Scores = _collectedCoins;
            LevelResultInfo.Scores = _collectedCoins;

            if (LevelConfig.CoinsAmount == _collectedCoins)
            {
                int _nexlLevelIndex = LevelIndex + 1;
                if (_nexlLevelIndex < levelsConfigs.EachLevelConfigs.Count
                    && GetLevelState(_nexlLevelIndex) == LevelState.Locked)
                {
                    SetLevelState(_nexlLevelIndex, LevelState.NeedUnlock);
                }
            }

            PlayerPrefs.Save();
        }

        public void ResetLevelResult() 
        {
            LevelResultInfo = new LevelResultInfo();
            LevelResultInfo.Scores = 0;
        }
    }

    public class LevelResultInfo 
    {
        public int Scores { get; set; }
    }


}

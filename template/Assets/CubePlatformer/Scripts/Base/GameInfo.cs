using System.Collections.Generic;
using CubePlatformer.Core;
using UnityEngine;

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
                SetLevelState(0, LevelState.Unlocked);                            
;           }
        }

        public LevelState GetLevelState(int _levelIndex)
        {
            int _levelIntState = AppPrefs.GetInt(PrefsKeys.Level_ + _levelIndex);
            return (LevelState)_levelIntState;
        }

        public void SetLevelState(int _levelIndex, LevelState _levelState) 
        {
            AppPrefs.SetInt(PrefsKeys.Level_ + _levelIndex, (int)_levelState);
        }

        public int Scores
        {
            get => AppPrefs.GetInt(PrefsKeys.Scores);
            set => AppPrefs.SetInt(PrefsKeys.Scores, value);
        }

        public float Time
        {
            get => AppPrefs.GetFloat(PrefsKeys.Time);
            set => AppPrefs.SetFloat(PrefsKeys.Time, value);
        }

        public string ConvertTime(float _time) 
        {
            float minutes = Mathf.FloorToInt(_time / 60);
            float seconds = Mathf.FloorToInt(_time % 60);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void RegisterResult(int _collectedCoins, float _time) 
        {
            LevelResultInfo = new LevelResultInfo();
            Scores = _collectedCoins;
            LevelResultInfo.Scores = _collectedCoins;
            LevelResultInfo.Time = _time;

            if (LevelConfig.CoinsAmount == _collectedCoins)
            {
                int _nexlLevelIndex = LevelIndex + 1;
                if (_nexlLevelIndex < levelsConfigs.EachLevelConfigs.Count
                    && GetLevelState(_nexlLevelIndex) == LevelState.Locked)
                {
                    SetLevelState(_nexlLevelIndex, LevelState.NeedUnlock);
                }
            }

            AppPrefs.Save();
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
        public float Time { get; set; }
    }
}

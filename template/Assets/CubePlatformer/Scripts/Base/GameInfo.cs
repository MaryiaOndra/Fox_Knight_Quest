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
        List<EachLevelConfigs> eachLevelConfigs;
        public List<EachLevelConfigs> EachLevelConfigs => eachLevelConfigs;

        public int LevelIndex { get; set; }
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

        public int Scores
        {
            get => PlayerPrefs.GetInt(PrefsKeys.Scores);
            set => PlayerPrefs.SetInt(PrefsKeys.Scores, value);
        }

        public void RegisterResult(int _truphyRemaining, bool _isFinalTruffy) 
        {
            LevelResultInfo = new LevelResultInfo();
            Scores += _truphyRemaining;

            if (_isFinalTruffy)
            {
                int _nexlLevelIndex = LevelIndex + 1;
                if (_nexlLevelIndex < eachLevelConfigs.Count 
                    && GetLevelState(_nexlLevelIndex) == LevelState.Locked)
                {
                    SetLevelState(_nexlLevelIndex, LevelState.NeedUnlock);
                }
            }

            PlayerPrefs.Save();
        }
    }

    public class LevelResultInfo 
    {
        public int Scores { get; set; }
    }

    [Serializable]
    public class EachLevelConfigs 
    {
        [SerializeField]
        int coinsCount;
        [SerializeField]
        LevelContentId id;
        [SerializeField]
        int buildIndex;

        bool isAllCoins;

        public int CoinsCount => coinsCount;
        public LevelContentId Id => id;
        public int BuildIndex => buildIndex;
        public bool FinishTruphy => isAllCoins;
    }
}

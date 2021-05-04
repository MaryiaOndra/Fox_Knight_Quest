using System;
using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Base;
using CubePlatformer.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class GameScreen : BaseScreen
    {
        [SerializeField]
        CubePlatformerController platformerController;
        [SerializeField]
        StatesPanel statesPanel;

        public const string Exit_Pause = "Exit_Pause";
        public const string Exit_Result = "Exit_Result";

        Level gameLevel;
        EachLevelConfigs levelConfigs;
        List<Coin> coins;
        PlayerController playerContr;

        int coinsCount = 0;

        public Action CoinsAction;

        private void OnEnable()
        {
            CoinsAction += CheckCoinsAmount;
        }
        private void OnDisable()
        {
            CoinsAction -= CheckCoinsAmount;
        }

        public void ShowAndStartGame()
        {
            Show();

            levelConfigs = GameInfo.Instance.LevelConfig;
            platformerController.StartGame(levelConfigs);
            GameInfo.Instance.ResetLevelResult();
            coinsCount = 0;
            statesPanel.ShowScores(coinsCount);
        }

        public void AddLevelData(Level _level) 
        {
            gameLevel = _level;
            playerContr = _level.PlayerCtrl;
            coins = _level.Coins;

            playerContr.PlayerDeathAction = OnResult;
            coins.ForEach(_coin => _coin.OnCoinColected = CheckCoinsAmount);
        }

        public void OnPause()
        {
            Exit(Exit_Pause);
        }

        public void OnResult()
        {
            GameInfo.Instance.RegisterResult(coinsCount);
            Exit(Exit_Result);          
        }

        void CheckCoinsAmount()
        {
            coinsCount += 1;
            statesPanel.ShowScores(coinsCount);

            if (coinsCount == levelConfigs.CoinsAmount)
            {                   
                OnResult();               
            }
        }

        public void LoadNextGameLevel()
        {
            Show();

            GameInfo.Instance.ResetLevelResult();
            coinsCount = 0;
            statesPanel.ShowScores(coinsCount);

            EachLevelConfigs _nextLevelConfigs = GameInfo.Instance.LevelConfig;
            platformerController.LoadNextLevel(levelConfigs, _nextLevelConfigs);

            levelConfigs = _nextLevelConfigs;
        }
    }
}

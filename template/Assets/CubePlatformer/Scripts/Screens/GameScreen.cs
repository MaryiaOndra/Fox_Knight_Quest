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

        public const string Exit_Pause = "Exit_Pause";
        public const string Exit_Result = "Exit_Result";

        Level gameLevel;

        EachLevelConfigs levelConfigs;
        int totalCount;
        int count = 0;
        List<Coin> coins;
        UIController uIController;
        PlayerController playerContr;

        private void OnEnable()
        {
            uIController = FindObjectOfType<UIController>();
        }

        public void ShowAndStartGame()
        {
            Show();
            levelConfigs = GameInfo.Instance.LevelConfig;
            platformerController.StartGame(levelConfigs);
            platformerController.FinishLevelAction += LoadDataFromLevel;
        }

        void LoadDataFromLevel() 
        {
            gameLevel = FindObjectOfType<Level>();
            CountCoinsInLevel(gameLevel.Coins);
        }

        //public void Setup(List<Coin> _coins, UIController _uIController, PlayerController _playerContr) 
        //{
        //    coins = _coins;
        //    uIController = _uIController;
        //    playerContr = _playerContr;

        //    CountCoinsInLevel(_coins);
        //}

        public void OnPause()
        {
            Exit(Exit_Pause);
        }

        public void OnResult()
        {
            Exit(Exit_Result);
        }

        void CountCoinsInLevel(List<Coin> _coins) 
        {
            _coins.ForEach(_coin => _coin.OnCoinColected += CheckCoinsAmount);
            uIController.WriteScoreText(_coins.Count);
        }

        void CheckCoinsAmount()
        {
            count += 1;
            uIController.WriteScoreText(count);
        }
    }
}

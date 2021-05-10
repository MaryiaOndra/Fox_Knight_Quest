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
        public const string Exit_Pause = "Exit_Pause";
        public const string Exit_Result = "Exit_Result";

        CubePlatformerController platformerController;
        StatesPanel statesPanel;
        NotesPanel notesPanel;
        EachLevelConfigs levelConfigs;
        PlayerController playerContr;
        Portal portal;

        int coinsCount = 0;

        public Action<Coin> CoinsAction;
        public Action<string> NotesAction;

        private void OnEnable()
        {
            statesPanel = FindObjectOfType<StatesPanel>();
            notesPanel = FindObjectOfType<NotesPanel>();
            platformerController = FindObjectOfType<CubePlatformerController>();

            CoinsAction = CheckCoinsAmount;
            NotesAction = notesPanel.ShowPanel;
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
            playerContr = _level.PlayerCtrl;

            portal = _level.Portal;
            portal.PortalAction = OnResult;
            playerContr.PlayerDeathAction = OnResult;

            _level.Coins.ForEach(_coin => _coin.OnCoinColected = CheckCoinsAmount);
            _level.Enemies.ForEach(_enemy => _enemy.AttackAction = playerContr.Attacked);
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

        void CheckCoinsAmount(Coin _coin)
        {
            SoundMgr.Instance.PlaySound(_coin.CoinClip);

            coinsCount += 1;
            statesPanel.ShowScores(coinsCount);

            if (coinsCount == levelConfigs.CoinsAmount)
            {
                portal.ActivatePortal();               
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

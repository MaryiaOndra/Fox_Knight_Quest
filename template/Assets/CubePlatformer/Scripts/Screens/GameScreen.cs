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
        public const string Exit_Loose = "Exit_Loose";
        public const string Exit_NextLvl = "Exit_NextLvl";

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

            CoinsAction = CheckCoinsAmount;
            NotesAction = notesPanel.ShowPanel;
        }

        public void ShowAndStartGame()
        {
            Show();
            levelConfigs = GameInfo.Instance.LevelConfig;
            LoadLevel(levelConfigs.LevelName);

            //GameInfo.Instance.ResetLevelResult();
            //coinsCount = 0;
            statesPanel.ShowScores(coinsCount);
        }

        public void RestartGame() 
        {
            Show();

            UnloadLevel(levelConfigs.LevelName);
            LoadLevel(levelConfigs.LevelName);

            GameInfo.Instance.ResetLevelResult();
            coinsCount = 0;
            statesPanel.ShowScores(coinsCount);
        }

        public void AddLevelData(Level _level) 
        {
            playerContr = _level.PlayerCtrl;

            portal = _level.Portal;
            portal.IsPortalAction = PortalPassing;
            playerContr.PlayerDeathAction = OnLoose;

            _level.Coins.ForEach(_coin => _coin.OnCoinColected = CheckCoinsAmount);
            _level.Enemies.ForEach(_enemy => _enemy.AttackAction = playerContr.Attacked);
        }

        void OnPause()
        {
            Exit(Exit_Pause);
        }

        void OnLoose()
        {
            Exit(Exit_Loose);          
        }

        void PortalPassing() 
        {
            GameInfo.Instance.RegisterResult(coinsCount);
            Exit(Exit_NextLvl);
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

            UnloadLevel(levelConfigs.LevelName);
            LoadLevel(_nextLevelConfigs.LevelName);

            levelConfigs = _nextLevelConfigs;
        }

        public void LoadNextLevel(EachLevelConfigs _prevLevelConfigs, EachLevelConfigs _nextLevelConfigs)
        {
            UnloadLevel(_prevLevelConfigs.LevelName);
            LoadLevel(_nextLevelConfigs.LevelName);
        }

        void LoadLevel(string _levelName)
        {
            SceneManager.LoadScene(_levelName, LoadSceneMode.Additive);
        }

        public void UnloadLevel(string _levelName)
        {
            SceneManager.UnloadSceneAsync(_levelName);
        }
    }
}

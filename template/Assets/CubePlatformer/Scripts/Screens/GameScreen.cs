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
        EachLevelConfigs loadedLevelConfigs;
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
            Time.timeScale = 1;

            levelConfigs = GameInfo.Instance.LevelConfig;

            if (loadedLevelConfigs != null)
            {
                UnloadLevel(loadedLevelConfigs.LevelName);
            }

            LoadLevel(levelConfigs.LevelName);

            GameInfo.Instance.ResetLevelResult();
            coinsCount = 0;

            loadedLevelConfigs = levelConfigs;
            statesPanel.ShowScores(coinsCount);
        }

        public void AddLevelData(Level _level)
        {
            playerContr = _level.PlayerController;

            portal = _level.Portal;
            portal.IsPortalAction = PortalPassing;
            playerContr.PlayerDeathAction = OnLoose;

            _level.Coins.ForEach(_coin => _coin.OnCoinColected = CheckCoinsAmount);
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
            _coin.Deactivate();

            coinsCount += 1;
            statesPanel.ShowScores(coinsCount);

            if (coinsCount == levelConfigs.CoinsAmount)
            {
                portal.ActivatePortal();
            }
        }

        void LoadLevel(string _levelName)
        {
            SceneManager.LoadScene(_levelName, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += ActivateScene;
        }

        void ActivateScene(Scene _scene, LoadSceneMode arg1)
        {
            SceneManager.SetActiveScene(_scene);
        }

        public void UnloadLevel(string _levelName)
        {
            SceneManager.UnloadSceneAsync(_levelName);
        }
    }
}

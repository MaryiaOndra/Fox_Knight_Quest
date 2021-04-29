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

        EachLevelConfigs levelConfigs;
        int truphyCount;

        public void ShowAndStartGame()
        {

            levelConfigs = GameInfo.Instance.LevelConfig;
            truphyCount = levelConfigs.CoinsCount;

            platformerController.StartGame(levelConfigs);
            Show();
        }

        public void OnPause()
        {
            Exit(Exit_Pause);
        }

        public void OnResult()
        {
            Exit(Exit_Result);
        }

        CharacterController chController;
        UIController uiController;
        PlayerController playerController;

        float platformAngle;

        List<Coin> coins;
        int totalCount;
        int count = 0;

        public override void Show()
        {
            base.Show();

            chController = FindObjectOfType<CharacterController>();
            uiController = FindObjectOfType<UIController>();
            playerController = FindObjectOfType<PlayerController>();
            coins = new List<Coin>(FindObjectsOfType<Coin>());

            coins.ForEach(_coin => _coin.OnCoinColected += CheckCoinsAmount);
            totalCount = coins.Count;
            Debug.Log("Coins:   " + coins.Count);
            uiController.WriteScoreText(coins.Count, totalCount); 
        }

        void CheckCoinsAmount()
        {
            count += 1;
            uiController.WriteScoreText(count, totalCount);
        }

        public void ChangeState(bool _state)
        {
            bool _plContrState = _state == true ? false : true;
            chController.enabled = _plContrState;
        }
    }
}

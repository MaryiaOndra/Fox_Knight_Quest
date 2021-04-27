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
            Show();
            levelConfigs = GameInfo.Instance.LevelConfig;
            truphyCount = levelConfigs.CoinsCount;

            if (true)
            {

            }
            platformerController.StartGame(levelConfigs);

        }



        public void OnPause()
        {
            Exit(Exit_Pause);
        }

        public void OnResult()
        {
            Exit(Exit_Result);
        }
    }
}

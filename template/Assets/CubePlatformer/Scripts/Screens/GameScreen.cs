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

        public void ShowAndStartGame() 
        {
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
    }
}

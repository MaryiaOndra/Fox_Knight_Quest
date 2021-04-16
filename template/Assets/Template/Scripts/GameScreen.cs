using System.Collections;
using System.Collections.Generic;
using Template.Base;
using Template.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template
{
    public class GameScreen : BaseScreen
    {
        public const string Exit_Settings = "Exit_Settings";
        public const string Exit_Result = "Exit_Result";

        public void ShowAndStartGame() 
        {
            Show();
            GameInfo.Instance.Score = 10;
        }

        public void OnSettingsPressed()
        {
            Exit(Exit_Settings);
        }


        public void OnGameEndScreen()
        {
            Exit(Exit_Result);
        }
    }
}

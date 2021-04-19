using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Base;
using CubePlatformer.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class MenuScreen : BaseScreen
    {
        public const string Exit_Settings = "Exit_Settings";
        public const string Exit_Game = "Exit_Game";

        public void OnSettingsPressed() 
        {
            Exit(Exit_Settings);
        }

        public void OnGamePressed()
        {
            Exit(Exit_Game);
        }
    }
}

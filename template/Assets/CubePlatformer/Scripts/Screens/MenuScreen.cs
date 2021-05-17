using CubePlatformer.Base;
using CubePlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class MenuScreen : BaseScreen
    {

        public const string Exit_Game = "Exit_Game";
        public const string Exit_Levels = "Exit_Levels";
        public const string Exit_Settings = "Exit_Settings";

        public void OnGamePressed()
        {
            SoundMgr.Instance.PlayBtnSound();

            Exit(Exit_Game);
        }

        public void OnLevelsPressed()
        {
            SoundMgr.Instance.PlayBtnSound();
            Exit(Exit_Levels);
        }
        public void OnSettingsPressed()
        {
            SoundMgr.Instance.PlayBtnSound();
            Exit(Exit_Settings);
        }
    }
}

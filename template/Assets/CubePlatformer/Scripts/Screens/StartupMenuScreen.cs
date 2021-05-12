using CubePlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class StartupMenuScreen : BaseScreen
    {
        public const string Exit_Game = "Exit_Game";
        public const string Exit_Levels = "Exit_Levels";
        public const string Exit_Settings = "Exit_Settings";

        public override void Show()
        {
            base.Show();

            SoundMgr.Instance.PlayMusic();
        }

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

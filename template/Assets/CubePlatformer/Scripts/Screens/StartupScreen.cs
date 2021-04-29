using CubePlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class StartupScreen : BaseScreen
    {
        public const string Exit_Game = "Exit_Game";

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
    }
}

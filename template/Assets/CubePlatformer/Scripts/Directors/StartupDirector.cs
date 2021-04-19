using CubePlatformer.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class StartupDirector : SceneDirector
    {
        protected override void Start()
        {
            base.Start();

            SetCurrentScreen<StartupScreen>().Show();
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(StartupScreen))
            {
                if (_exitCode == StartupScreen.Exit_Game)
                {
                    SceneManager.LoadScene(ScenesIds.Game);
                }
            }
        }
    }
}

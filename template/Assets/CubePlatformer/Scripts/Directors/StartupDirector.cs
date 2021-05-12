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

            SetCurrentScreen<StartupMenuScreen>().Show();
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(StartupMenuScreen))
            {
                if (_exitCode == StartupMenuScreen.Exit_Game)
                {
                    SceneManager.LoadScene(ScenesIds.Game);
                }
            }
        }
    }
}

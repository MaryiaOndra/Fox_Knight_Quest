using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CubePlatformer.Core;
using System;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class MenuDirector : SceneDirector
    {
        protected override void Start()
        {
            base.Start();

            SetCurrentScreen<MenuScreen>().Show();
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(MenuScreen))
            {
                if (_exitCode == MenuScreen.Exit_Game)
                {
                    SceneManager.LoadScene(ScenesIds.Game);
                }
                else if (_exitCode == MenuScreen.Exit_Levels)
                {
                    SetCurrentScreen<LevelsScreen>().Show();
                }
            }
            else if (_screenType == typeof(LevelsScreen))
            {
                if (_exitCode == LevelsScreen.Exit_Menu)
                {
                    ToBackScreen();
                }
                else if (_exitCode == LevelsScreen.Exit_Game)
                {
                    SceneManager.LoadScene(ScenesIds.Game);
                }
            }
        }
    }
}

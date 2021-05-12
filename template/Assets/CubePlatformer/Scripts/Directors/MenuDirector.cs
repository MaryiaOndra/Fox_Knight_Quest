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
                else if (_exitCode == StartupMenuScreen.Exit_Levels)
                {
                    SetCurrentScreen<LevelsScreen>().Show();
                }             
                else if (_exitCode == StartupMenuScreen.Exit_Settings)
                {
                    SetCurrentScreen<SettingsScreen>().Show();
                }
            }
           else if (_screenType == typeof(LevelsScreen))
           {
                if (_exitCode == LevelsScreen.Exit_Menu)
                {
                    ToBackScreen();
                }
                else if (_exitCode == LevelsScreen.Exit_Settings) 
                {
                    SetCurrentScreen<SettingsScreen>().Show();
                }                    
           }
            else if (_screenType == typeof(SettingsScreen)) 
            {
                if (_exitCode == SettingsScreen.Exit_Back) 
                {
                    ToBackScreen();
                }
            }
        }
    }
}

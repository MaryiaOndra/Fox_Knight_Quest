using System;
using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class GameDirector : SceneDirector
    {
        protected override void Start()
        {
            base.Start();

            SetCurrentScreen<GameScreen>().ShowAndStartGame();
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
                else if (_exitCode == MenuScreen.Exit_Settings)
                {
                    SetCurrentScreen<SettingsScreen>().Show();
                }
            }
            else if (_screenType == typeof(GameScreen))
            {
                if (_exitCode == GameScreen.Exit_Pause)
                {
                    SetCurrentScreen<PauseScreen>().Show();
                }
                else if (_exitCode == GameScreen.Exit_Loose)
                {
                    SetCurrentScreen<LooseScreen>().Show();
                }
                else if (_exitCode == GameScreen.Exit_NextLvl)
                {
                    SetCurrentScreen<VictoryScreen>().Show();
                }
            }
            else if (_screenType == typeof(PauseScreen))
            {
                if (_exitCode == PauseScreen.Exit_Back) 
                {
                    ToBackScreen();
                }
                else if (_exitCode == PauseScreen.Exit_Replay) 
                {
                    SetCurrentScreen<GameScreen>().ShowAndStartGame();
                }
                else if (_exitCode == PauseScreen.Exit_Menu)
                {
                    SceneManager.LoadScene(ScenesIds.Menu);
                }
                else if (_exitCode == PauseScreen.Exit_Settings)
                {
                    SetCurrentScreen<SettingsScreen>().Show();
                }
            }
            else if (_screenType == typeof(LooseScreen))
            {
                if (_exitCode == LooseScreen.Exit_Replay)
                {
                    SetCurrentScreen<GameScreen>().ShowAndStartGame();
                }
                if (_exitCode == LooseScreen.Exit_Return)
                {
                    SetCurrentScreen<GameScreen>().ReturnAfterFall();
                }
            }
            else if (_screenType == typeof(VictoryScreen))
            {
                if (_exitCode == VictoryScreen.Exit_NextLvl)
                {
                    SetCurrentScreen<GameScreen>().ShowAndStartGame();
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

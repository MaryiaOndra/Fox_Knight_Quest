using System;
using CubePlatformer.Core;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class GameDirector : SceneDirector
    {
        protected override void Start()
        {
            base.Start();

            SetCurrentScreen<LoadingScreen>().Show();
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(LoadingScreen))
            {
                if (_exitCode == LoadingScreen.Exit_Game)
                {
                    SetCurrentScreen<GameScreen>().ShowAndStartGame();
                }
            }
            else if (_screenType == typeof(GameScreen))
            {
                if (_exitCode == GameScreen.Exit_Menu)
                {
                    SceneManager.LoadScene(ScenesIds.Menu);
                }
                else if (_exitCode == GameScreen.Exit_Loading)
                {
                    SetCurrentScreen<LoadingScreen>().Show();
                }
            }
        }
    }
}

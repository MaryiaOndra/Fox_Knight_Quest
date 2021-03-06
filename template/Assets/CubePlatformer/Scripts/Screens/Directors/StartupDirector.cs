using CubePlatformer.Core;
using System;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class StartupDirector : SceneDirector
    {
        protected override void Start()
        {
            base.Start();

            SetCurrentScreen<MenuScreen>().ShowScreen();
        }

        protected override void OnScreenExit(Type _screenType, string _exitCode)
        {
            if (_screenType == typeof(MenuScreen))
            {
                if (_exitCode == MenuScreen.Exit_Game)
                {
                    SceneManager.LoadScene(ScenesIds.Game);
                }
            }
        }
    }
}

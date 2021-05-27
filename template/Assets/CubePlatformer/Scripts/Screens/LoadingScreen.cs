using CubePlatformer.Base;
using CubePlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class LoadingScreen : BaseScreen
    {
        public const string Exit_Game = "Exit_Game";

        EachLevelConfigs levelConfigs;
        EachLevelConfigs loadedLevelConfigs;

        AsyncOperation loadingScene;

        public override void Show()
        {
            base.Show();

            levelConfigs = GameInfo.Instance.LevelConfig;

            if (loadedLevelConfigs != null)
            {
                UnloadLevel(loadedLevelConfigs.LevelName);
            }

            LoadLevel(levelConfigs.LevelName);
            loadedLevelConfigs = levelConfigs;
        }

        void LoadLevel(string _levelName)
        {
            loadingScene = SceneManager.LoadSceneAsync(_levelName, LoadSceneMode.Additive);
            StartCoroutine(ControlLoading(_levelName));
        }

        public IEnumerator ControlLoading(string _levelName) 
        {
            while (!loadingScene.isDone)
            {
                yield return null;
            }

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_levelName));

            Exit(Exit_Game);
        }

        void UnloadLevel(string _levelName)
        {
            SceneManager.UnloadSceneAsync(_levelName);
        }
    }
}

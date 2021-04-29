using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
using CubePlatformer.Base;

namespace CubePlatformer
{
    public class CubePlatformerController : MonoBehaviour
    {
        public Action FinishLevelAction { get; set; }

        public void StartGame(EachLevelConfigs _levelConfigs) 
        {
            if (SceneManager.GetSceneByName(_levelConfigs.LevelName).isLoaded)
            {
                SceneManager.UnloadSceneAsync(_levelConfigs.LevelName);
            }
                        
            LoadLevel(_levelConfigs.LevelName);

            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            FinishLevelAction.Invoke();
        }

        void LoadLevel(string _levelName)
        {
            SceneManager.LoadScene(_levelName, LoadSceneMode.Additive);
        }

        public void UnloadLevel(string _levelName)
        {
            SceneManager.UnloadScene(_levelName);
        }
    }
}

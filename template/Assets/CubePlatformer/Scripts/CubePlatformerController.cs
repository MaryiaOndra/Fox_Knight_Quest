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
        public Action StartLevelAction { get; set; }

        public void StartGame(EachLevelConfigs _levelConfigs) 
        {
            if (SceneManager.GetSceneByName(_levelConfigs.LevelName).isLoaded)
            {
                UnloadLevel(_levelConfigs.LevelName);
            }
                        
            LoadLevel(_levelConfigs.LevelName);           
        }

        public void LoadNextLevel(EachLevelConfigs _prevLevelConfigs, EachLevelConfigs _nextLevelConfigs ) 
        {
            UnloadLevel(_prevLevelConfigs.LevelName);
            LoadLevel(_nextLevelConfigs.LevelName);
        }

        void LoadLevel(string _levelName)
        {
            SceneManager.LoadScene(_levelName, LoadSceneMode.Additive);
        }

        public void UnloadLevel(string _levelName)
        {
            SceneManager.UnloadSceneAsync(_levelName);
        }
    }
}

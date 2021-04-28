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
        public Action<int> ColectedAction { get; set; }
        public Action<bool> FinishLevelAction { get; set; }

        public void StartGame(EachLevelConfigs _levelConfigs) 
        {
            if (SceneManager.GetSceneByBuildIndex(_levelConfigs.BuildIndex).isLoaded)
            {
                UnloadLevel(_levelConfigs.BuildIndex);
            }

            Debug.Log("Layer" + _levelConfigs.BuildIndex);
            LoadLevel(_levelConfigs.BuildIndex);
        }
        void LoadLevel(int _buildIndex)
        {
            SceneManager.LoadScene(_buildIndex, LoadSceneMode.Additive);
        }

        public void UnloadLevel(int _buildIndex)
        {
            SceneManager.UnloadScene(_buildIndex);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Base;
using CubePlatformer.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class GameScreen : BaseScreen
    {
        public const string Exit_Pause = "Exit_Pause";
        public const string Exit_Result = "Exit_Result";

        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        public void ShowAndStartGame() 
        {
            Show();
            LoadLevel(3);
        }
               
        void LoadLevel(int _buildIndex) 
        {
            SceneManager.LoadScene(_buildIndex, LoadSceneMode.Additive);
        }

        public void UnloadLevel(int _buildIndex) 
        {
            SceneManager.UnloadScene(_buildIndex);
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);

            UIController uiContr = GetComponentInChildren<UIController>();
            Debug.Log("uiContr.Setup();");
            uiContr.Setup();
        }


    public void OnPause()
        {
            Exit(Exit_Pause);
        }

        public void OnResult() 
        {
            Exit(Exit_Result);
        }
    }
}

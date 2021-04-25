﻿using System.Collections;
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

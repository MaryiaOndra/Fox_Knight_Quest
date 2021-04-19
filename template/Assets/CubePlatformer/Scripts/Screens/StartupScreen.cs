using CubePlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class StartupScreen : BaseScreen
    {
        public const string Exit_Game = "Exit_Game";

        public void OnGamePressed()
        {
            Exit(Exit_Game);
        }
    }
}

using CubePlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class SettingsScreen : BaseScreen
    {
        public const string Exit_Back = "Exit_Back";

        public void OnBackPressed()
        {
            Exit(Exit_Back);
        }
    }
}

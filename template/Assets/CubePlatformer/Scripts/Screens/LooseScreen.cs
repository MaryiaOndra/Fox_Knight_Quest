using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Base;
using CubePlatformer.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class LooseScreen : BaseScreen
    {
        public const string Exit_Replay = "Exit_Replay";
       
        public override void Show()
        {
            base.Show();
            Time.timeScale = 0;

        }

        public void OnRestartPressed()
        {
            Time.timeScale = 1;
            Exit(Exit_Replay);
        }
    }
}

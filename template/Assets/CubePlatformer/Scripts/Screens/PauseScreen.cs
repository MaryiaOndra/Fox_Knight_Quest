using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Core;
using UnityEngine;

namespace CubePlatformer
{
    public class PauseScreen : BaseScreen
    {
        public const string Exit_Back = "Exit_Back";
        public const string Exit_Replay = "Exit_Replay";
        public const string Exit_Menu = "Exit_Menu";

        public void OnBackPressed() 
        {
            Exit(Exit_Back);
        }
        public void OnReplyPressed() 
        {
            Exit(Exit_Replay);
        }
        public void OnMenuPressed() 
        {
            Exit(Exit_Menu);
        }
    }
}

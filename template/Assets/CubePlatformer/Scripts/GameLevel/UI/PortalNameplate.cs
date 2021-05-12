using CubePlatformer.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class PortalNameplate : Nameplate
    {
        protected override void InvokeNameplate(string _frase)
        {
            Debug.Log(GameInfo.Instance.LevelConfig.LevelName +   "GameInfo.Instance.LevelConfig.CoinsAmount " + GameInfo.Instance.LevelConfig.CoinsAmount);
            _frase += GameInfo.Instance.LevelConfig.CoinsAmount + " coin";

            base.InvokeNameplate(_frase);
        }
    }
}

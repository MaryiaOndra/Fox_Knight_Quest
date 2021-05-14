using CubePlatformer.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class PortalNameplate : Nameplate
    {
        const string UNIT_COIN = " coins";

        int CoinsAmount 
        {
            get => GameInfo.Instance.LevelConfig.CoinsAmount;
        }

        protected override void InvokeNameplate(string _frase)
        {          
            _frase += CoinsAmount + UNIT_COIN;

            base.InvokeNameplate(_frase);
        }
    }
}

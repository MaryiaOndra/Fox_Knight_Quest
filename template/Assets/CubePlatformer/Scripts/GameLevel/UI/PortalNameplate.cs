using CubePlatformer.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class PortalNameplate : Nameplate
    {
        const string UNIT_COIN = " coins";

        protected override void InvokeNameplate(string _frase)
        {    
            int _coinsAmount = GameInfo.Instance.LevelConfig.CoinsAmount;
            _frase += _coinsAmount + UNIT_COIN;

            base.InvokeNameplate(_frase);
        }
    }
}

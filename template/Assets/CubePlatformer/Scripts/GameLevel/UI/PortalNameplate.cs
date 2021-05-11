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
            _frase += GameInfo.Instance.LevelConfig.CoinsAmount + " coin";

            base.InvokeNameplate(_frase);
        }
    }
}

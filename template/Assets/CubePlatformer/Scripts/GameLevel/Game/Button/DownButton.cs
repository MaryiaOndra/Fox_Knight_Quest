using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class DownButton : BaseBtn
    {
        public override BtnState ButtonState => BtnState.MoveBack;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class LeftBtn : BaseBtn
    {
        public override BtnState ButtonState => BtnState.MoveLeft;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class JumpBtn : BaseBtn
    {
        public override BtnState ButtonState => BtnState.Jump;
    }
}

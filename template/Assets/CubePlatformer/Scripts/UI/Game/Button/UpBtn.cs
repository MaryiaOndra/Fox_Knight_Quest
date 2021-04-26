using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CubePlatformer
{
    public class UpBtn : BaseBtn
    {
        public override BtnState ButtonState => BtnState.MoveForward;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class GetHit : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Attacked;
    }
}

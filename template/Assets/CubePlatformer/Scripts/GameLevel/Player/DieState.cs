using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class DieState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Die;
    }
}

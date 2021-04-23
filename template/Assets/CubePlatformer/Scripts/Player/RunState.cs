using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class RunState : BaseState
    {
        [SerializeField]
        float moveSpeed;
        public override PlayerState PlayerState => PlayerState.Run;

    }
}

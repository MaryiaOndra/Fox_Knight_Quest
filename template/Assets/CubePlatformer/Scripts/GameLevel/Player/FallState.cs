using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class FallState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Fall;
        public override void Activate()
        {
            base.Activate();

            playerAnimator.SetInteger(INT_STATE, (int)PlayerState.Fall);
        }
    }
}

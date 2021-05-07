using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class DieState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Die;

        public override void Activate()
        {
            base.Activate();

            playerAnimator.SetInteger(INT_STATE, (int)PlayerState.Die);
        }
    }
}

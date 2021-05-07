using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class AttackedState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Attacked;
        public override void Activate()
        {
            base.Activate();

            playerAnimator.SetInteger(INT_STATE, (int)PlayerState.Attacked);
        }
    }
}

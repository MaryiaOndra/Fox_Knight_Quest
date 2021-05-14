using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class FallState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Fall;

        void Update()
        {
            if (OnGrounded)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
            else
            {
            }
        }
    }
}

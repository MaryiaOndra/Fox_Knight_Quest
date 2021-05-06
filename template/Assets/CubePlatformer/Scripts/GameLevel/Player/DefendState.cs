using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class DefendState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Defend;

        private void Update()
        {
            if (Input.GetMouseButtonUp(1))
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
        }
    }
}

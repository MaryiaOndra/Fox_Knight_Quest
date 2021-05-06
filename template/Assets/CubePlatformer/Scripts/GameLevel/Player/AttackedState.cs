using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class AttackedState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Attacked;

        private void Update()
        {
            NextStateAction.Invoke(PlayerState.Idle);   
        }
    }
}

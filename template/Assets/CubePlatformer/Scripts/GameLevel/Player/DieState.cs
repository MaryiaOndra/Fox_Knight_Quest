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
                        
            playerAnimator.GetBehaviour<DeadListener>().DieAction = PlayerDeath;
        }

        void PlayerDeath() 
        {
            GetComponentInParent<PlayerController>().PlayerDeathAction.Invoke();
        }
    }
}

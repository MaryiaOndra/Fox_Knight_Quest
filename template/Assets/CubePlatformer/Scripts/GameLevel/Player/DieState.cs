using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class DieState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Die;

        float gravityValue = -9.81f;
        Vector3 playerVelocity;

        private void Update()
        {
            playerVelocity = chController.velocity;
            playerVelocity.y += gravityValue * Time.deltaTime;
            chController.Move(playerVelocity * Time.deltaTime);
        }
    }
}

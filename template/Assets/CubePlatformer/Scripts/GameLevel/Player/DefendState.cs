using UnityEngine;

namespace CubePlatformer
{
    public class DefendState : BaseState
    {
        [SerializeField]
        AudioClip defend;

        public override PlayerState PlayerState => PlayerState.Defend;

        public override void Activate()
        {
            base.Activate();

            playerAudioSource.PlayOneShot(defend);
        }

        private void Update()
        {
            if (!VirtualInputManager.Instance.Defend)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
            else if (IsAttackFinished && VirtualInputManager.Instance.Attack)
            {
                NextStateAction.Invoke(PlayerState.Attack);
            }
            else if (VirtualInputManager.Instance.MoveHorizontal != 0)
            {
                var y = playerRB.rotation;
                y.y = VirtualInputManager.Instance.MoveHorizontal;
            }
        }
    }
}

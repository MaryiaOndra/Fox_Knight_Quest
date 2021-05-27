using UnityEngine;

namespace CubePlatformer
{
    public class FallState : BaseState
    {
        [SerializeField]
        AudioClip landing;

        public override PlayerState PlayerState => PlayerState.Fall;

        void Update()
        {
            playerRB.velocity += Physics.gravity * Time.deltaTime;

            if (OnGrounded)
            {
                NextStateAction.Invoke(PlayerState.Idle);
                playerAudioSource.PlayOneShot(landing);
            }
        }
    }
}

using UnityEngine;

namespace CubePlatformer
{
    public class RunState : BaseState
    {
        [SerializeField]
        AudioClip steps;

        [SerializeField]
        Transform cameraTr;

        [SerializeField]
        float playerSpeed = 2.0f;

        [SerializeField]
        float rotationSpeed = 500f;

        public override PlayerState PlayerState => PlayerState.Run;

        public override void Activate()
        {
            base.Activate();

            playerAudioSource.PlayOneShot(steps);
        }

        private void FixedUpdate()
        {
            Vector3 _camR = cameraTr.right;
            Vector3 _camF = cameraTr.forward;
            _camF.y = 0;
            _camR.y = 0;
            _camF = _camF.normalized;
            _camR = _camR.normalized;

            Vector3 _direction = (_camF * Direction.z + _camR * Direction.x).normalized;
            playerRB.MovePosition(playerRB.position + Time.deltaTime * playerSpeed * _direction);

            if (!_direction.Equals(Vector3.zero))
            {
                Quaternion _toRotation = Quaternion.LookRotation(_direction);
                playerRB.rotation = Quaternion.RotateTowards(playerRB.rotation, _toRotation, Time.fixedDeltaTime * rotationSpeed);
            }
        }

        private void Update()
        {
            if (OnGrounded)
            {
                if (Direction.x == 0 && Direction.z == 0)
                {
                    playerAudioSource.Stop();
                    NextStateAction.Invoke(PlayerState.Idle);
                }
            }
            else if (playerRB.velocity.y < VELOCITY_TO_FALL)
            {
                playerAudioSource.Stop();
                NextStateAction.Invoke(PlayerState.Fall);
            }
        }
    }
}

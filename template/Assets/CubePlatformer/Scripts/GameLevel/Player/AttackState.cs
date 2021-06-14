using UnityEngine;

namespace CubePlatformer
{
    public class AttackState : BaseState
    {
        public override PlayerState PlayerState => PlayerState.Attack;

        [SerializeField]
        AudioClip emptyAttack;
        
        [SerializeField]
        AudioClip enemyAttack;

        SwordTrigger attackTrigger;

        private void OnEnable()
        {
            attackTrigger = FindObjectOfType<SwordTrigger>();
            attackTrigger.SwordAttackAction = AttackEnemy;
        }

        public override void Activate()
        {
            base.Activate();
            playerAudioSource.PlayOneShot(emptyAttack);
        }

        void AttackEnemy(Collider _enemyCollider, int _damage) 
        {
            _enemyCollider.GetComponent<Enemy>().TakeDamage(_damage);
            playerAudioSource.PlayOneShot(enemyAttack);
        }

        private void Update()
        {
            if (!VirtualInputManager.Instance.Attack)
            {
                NextStateAction.Invoke(PlayerState.Idle);
            }
            else if (Direction.x != 0 || Direction.z != 0)
            {
                NextStateAction.Invoke(PlayerState.Run);
            }
            else if (VirtualInputManager.Instance.Defend)
            {
                NextStateAction.Invoke(PlayerState.Defend);
            }
        }
    }
}

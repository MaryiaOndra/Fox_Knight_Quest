using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    [CreateAssetMenu(fileName = "Enemy Configs", menuName = "CubePlatformer/Cteate Enemy Config")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField]
        EnemyType enemyType;
        [SerializeField]
        int maxHealth;
        [SerializeField]
        int attackPower;
        [SerializeField]
        float attackDelay;

        public int MaxHealth => maxHealth;
        public int AttackPower => attackPower;
        public float AttackDelay => attackDelay;
        public EnemyType Type => enemyType;
    }

    public enum EnemyType
    {
        Slime,
        TurtleShell
    }
}

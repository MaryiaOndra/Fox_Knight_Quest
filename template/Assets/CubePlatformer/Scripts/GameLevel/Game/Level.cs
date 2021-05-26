using CubePlatformer.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Level : MonoBehaviour
    {
        public PlayerController PlayerController { get; private set; }
        public List<Coin> Coins { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        public Portal Portal { get; private set; }
        public List<Nameplate> Nameplates { get; private set; }

        private void OnEnable()
        {
            Enemies.ForEach(_enemy => _enemy.AttackAction = PlayerController.GetHit);
        }

        private void Awake()
        {
            Portal = FindObjectOfType<Portal>(true);
            PlayerController = FindObjectOfType<PlayerController>(true);
            Coins = new List<Coin>(FindObjectsOfType<Coin>(true));
            Enemies = new List<Enemy>(FindObjectsOfType<Enemy>(true));
            Nameplates = new List<Nameplate>(FindObjectsOfType<Nameplate>(true));

            CheckCoinsAmount(Coins.Count);
        }

        void CheckCoinsAmount(int _lvlCoins) 
        {
            int _expectedCoins = GameInfo.Instance.LevelConfig.CoinsAmount;

            if (_lvlCoins < _expectedCoins)
            {
                throw new System.Exception($"The mismatch in the number of coins. Actual number of coins: {_lvlCoins}, Expected number of coins:{_expectedCoins}");
            }
        }
    }
}

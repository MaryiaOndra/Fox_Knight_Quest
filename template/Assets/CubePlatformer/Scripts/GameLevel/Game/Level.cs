using CubePlatformer.Base;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Level : MonoBehaviour
    {
        public string LevelName { get => GameInfo.Instance.LevelConfig.LevelName; }

        public PlayerController PlayerContr { get; private set; }
        public List<Coin> Coins { get; private set; }
        public List<Enemy> Enemies { get; private set; }
        public Portal Portal { get; private set; }
        public List<Nameplate> Nameplates { get; private set; }
        public CameraRotator Rotator { get; private set; }

        public void GetLevelData()
        {
            Portal = FindObjectOfType<Portal>(true);
            PlayerContr = FindObjectOfType<PlayerController>(true);
            Coins = new List<Coin>(FindObjectsOfType<Coin>(true));
            Enemies = new List<Enemy>(FindObjectsOfType<Enemy>(true));
            Nameplates = new List<Nameplate>(FindObjectsOfType<Nameplate>(true));
            Rotator = FindObjectOfType<CameraRotator>(true);

            Enemies.ForEach(_enemy => _enemy.AttackAction = PlayerContr.GetHit);
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

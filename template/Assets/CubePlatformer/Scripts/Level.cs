using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Level : MonoBehaviour
    {
        public PlayerController PlayerCtrl { get; private set; }
        public List<Coin> Coins { get; private set; }
      
        private void Awake()
        {
            PlayerCtrl = FindObjectOfType<PlayerController>();
            Coins = new List<Coin>(FindObjectsOfType<Coin>());

            GameScreen _gameScreen = FindObjectOfType<GameScreen>();
            _gameScreen.AddLevelData(this);            
        }
    }
}

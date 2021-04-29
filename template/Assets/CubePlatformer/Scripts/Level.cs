using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Level : MonoBehaviour
    {
        public PlayerController PlayerContr { get; private set; }
        public List<Coin> Coins { get; private set; }
      
        private void OnEnable()
        {
            PlayerContr = FindObjectOfType<PlayerController>();
            Coins = new List<Coin>(FindObjectsOfType<Coin>());
        }
    }
}

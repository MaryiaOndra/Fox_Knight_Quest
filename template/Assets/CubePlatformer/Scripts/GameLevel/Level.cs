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

        GameScreen gameScreen;
        List<Nameplate> nameplates;

        private void Awake()
        {
            Portal = FindObjectOfType<Portal>(true);
            PlayerController = FindObjectOfType<PlayerController>(true);
            Coins = new List<Coin>(FindObjectsOfType<Coin>(true));
            Enemies = new List<Enemy>(FindObjectsOfType<Enemy>(true));
            nameplates = new List<Nameplate>(FindObjectsOfType<Nameplate>(true));

            Enemies.ForEach(_enemy => _enemy.AttackAction = PlayerController.GetHit);
            Enemies.ForEach(_enemy => PlayerController.PlayerAttack = _enemy.TakeDamage);
            nameplates.ForEach(_nameplate => _nameplate.ActivateNameplate = ShowPanelOnGameScreen);

            gameScreen = FindObjectOfType<GameScreen>();
            gameScreen.AddLevelData(this);
        }


        void ShowPanelOnGameScreen(string _nameplateFrase) 
        {
            gameScreen.NotesAction.Invoke(_nameplateFrase);        
        }
    }
}

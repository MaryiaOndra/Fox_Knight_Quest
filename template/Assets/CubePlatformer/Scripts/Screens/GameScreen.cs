using System;
using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Base;
using CubePlatformer.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer
{
    public class GameScreen : BaseScreen
    {
        [SerializeField]
        GameObject androidBtns;

        public const string Exit_Menu = "Exit_Menu";
        //public const string Exit_Loose = "Exit_Loose";
        //public const string Exit_NextLvl = "Exit_NextLvl";

        StatesPanel statesPanel;
        NotesPanel notesPanel;
        EachLevelConfigs levelConfigs;
        EachLevelConfigs loadedLevelConfigs;
        PlayerController playerContr;
        Portal portal;

        List<BasePopup> popups;
        BasePopup activePopup;

        int coinsCount = 0;
        Vector3 startPlayerPos;

        public Action<Coin> CoinsAction;
        public Action<string> NotesAction;

        private void Awake()
        {
            statesPanel = FindObjectOfType<StatesPanel>();
            notesPanel = FindObjectOfType<NotesPanel>();

            CoinsAction = CheckCoinsAmount;
            NotesAction = notesPanel.ShowPanel;

            popups = new List<BasePopup>(GetComponentsInChildren<BasePopup>(true));

            popups.ForEach(_popup =>
            {
                _popup.PopupShowAction = ActivatePopup;            
            });

#if UNITY_STANDALONE
            androidBtns.SetActive(false);
#endif

#if UNITY_ANDROID
            androidBtns.SetActive(true);
#endif
        }

        public void ShowAndStartGame()
        {
            Show();
            Time.timeScale = 1;

            levelConfigs = GameInfo.Instance.LevelConfig;

            if (loadedLevelConfigs != null)
            {
                UnloadLevel(loadedLevelConfigs.LevelName);
            }

            LoadLevel(levelConfigs.LevelName);

            GameInfo.Instance.ResetLevelResult();
            coinsCount = 0;

            loadedLevelConfigs = levelConfigs;
            statesPanel.ShowScores(coinsCount);
        }

        public void AddLevelData(Level _level)
        {
            playerContr = _level.PlayerController;

            portal = _level.Portal;
            portal.IsPortalAction = ShowVictoryPopup;
            playerContr.PlayerDeathAction = OnLoose;
            playerContr.PlayerReturnAction = OnTryAgain;
            startPlayerPos = playerContr.transform.position;

            _level.Coins.ForEach(_coin => _coin.OnCoinColected = CheckCoinsAmount);
        }

        public void OnPause() 
        {
            ActivatePopup(Popup.Pause);
        }

        void ActivatePopup(Popup _popup) 
        {
            activePopup = popups.Find(_p => _p.ScreenPopup == _popup);

            switch(_popup) 
            {
                case Popup.TryAgain:
                    var _popTr = activePopup.GetComponent<TryAgainPopup>();
                    _popTr.ReturnAction = ReturnAfterAdvertisment;
                    _popTr.ReturnMinusHealthAction = ReturnLoosingHealth;
                    break;

                case Popup.Victory:
                    var _popV = activePopup.GetComponent<VictoryPopUp>();
                    _popV.NextLevelAction = GoToNextLevel;
                    break;

                case Popup.Pause:
                    var _popP = activePopup.GetComponent<PausePopup>();
                    _popP.BackPressedAction = Return;
                    _popP.MenuPressedAction = GoToMenu;
                    _popP.ReplyPressedAction = Restart;
                    _popP.SettingsPressedAction = ShowSettingsPopup;
                    break;

                case Popup.Loose:
                    var _popL = activePopup.GetComponent<LoosePopup>();
                    _popL.MenuPressedAction = GoToMenu;
                    _popL.RestartAction = Restart;
                    break;            
            }

            activePopup.Show();
        }

        void OnTryAgain() 
        {
            ActivatePopup(Popup.TryAgain);
        }

        void Return()
        {
            activePopup.Hide();
            Show();
        }

        void Restart() 
        {
            activePopup.Hide();
            ShowAndStartGame();
        }
        
        void ReturnLoosingHealth()
        {
            playerContr.GetHit(1);
            activePopup.Hide();
            playerContr.ReturnToStartPos(startPlayerPos);
            Show();
        }

        void ReturnAfterAdvertisment()
        {
            activePopup.Hide();
            playerContr.ReturnToStartPos(startPlayerPos);
            Show();
        }

        void GoToMenu()
        {
            Exit(Exit_Menu);
        }

        void OnLoose()
        {
            ActivatePopup(Popup.Loose);
        }

        void ShowSettingsPopup() 
        {
            activePopup.Hide();
            ActivatePopup(Popup.Settings);        
        }

        void ShowVictoryPopup()
        {
            GameInfo.Instance.RegisterResult(coinsCount);
            ActivatePopup(Popup.Victory);
        }

        void GoToNextLevel() 
        {
            activePopup.Hide();
            ShowAndStartGame();
        }

        void CheckCoinsAmount(Coin _coin)
        {
            SoundMgr.Instance.PlaySound(_coin.CoinClip);
            _coin.Deactivate();

            coinsCount += 1;
            statesPanel.ShowScores(coinsCount);

            if (coinsCount == levelConfigs.CoinsAmount)
            {
                portal.ActivateVictoryPortal();
            }
        }

        void LoadLevel(string _levelName)
        {
            SceneManager.LoadScene(_levelName, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += ActivateScene;
        }

        void ActivateScene(Scene _scene, LoadSceneMode arg1)
        {
            SceneManager.SetActiveScene(_scene);
        }

        void UnloadLevel(string _levelName)
        {
            SceneManager.UnloadSceneAsync(_levelName);
        }
    }
}

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
        public const string Exit_Loading = "Exit_Loading";

        StatesPanel statesPanel;
        NotesPanel notesPanel;
        EachLevelConfigs levelConfigs;
        PlayerController playerContr;
        Portal portal;
        Level activeLevel;
        TouchPanel touchPanel;

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
            touchPanel = FindObjectOfType<TouchPanel>();

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

            GameInfo.Instance.ResetLevelResult();
            coinsCount = 0;

            statesPanel.ShowScores(coinsCount);
            statesPanel.ShowHealth(playerContr.PlayerHealth);
        }

        private void OnEnable()
        {
            activeLevel = FindObjectOfType<Level>();
            AddLevelData(activeLevel);
        }

        public void AddLevelData(Level _level)
        {
            playerContr = _level.PlayerController;
            portal = _level.Portal;
            portal.IsPortalAction = ShowVictoryPopup;
            playerContr.PlayerDeathAction = OnLoose;
            playerContr.PlayerReturnAction = OnTryAgain;
            playerContr.ChangeHealthAction = statesPanel.ShowHealth;
            startPlayerPos = playerContr.transform.position;
            touchPanel.DragAction = _level.Rotator.DragDelta;

            _level.Coins.ForEach(_coin => _coin.OnCoinColected = CheckCoinsAmount);
            _level.Nameplates.ForEach(_nameplate => _nameplate.ActivateNameplate = notesPanel.ShowPanel);
        }

        #region POPUPS

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
            LoadGame();
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
            GameInfo.Instance.LevelIndex += 1;
        }

        #endregion

        void GoToNextLevel() 
        {
            activePopup.Hide();
            LoadGame();
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
        void LoadGame()
        {
            Exit(Exit_Loading);
        }

        void GoToMenu()
        {
            Exit(Exit_Menu);
        }

    }
}

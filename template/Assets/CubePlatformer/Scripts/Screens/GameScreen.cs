﻿using System;
using System.Collections.Generic;
using CubePlatformer.Base;
using CubePlatformer.Core;
using UnityEngine;
using UnityEngine.Analytics;

namespace CubePlatformer
{
    public class GameScreen : BaseScreen
    {
        [SerializeField]
        GameObject androidBtns;    
        [SerializeField]
        GameObject keyboardInput;

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
        float timeToDisplay;
        Vector3 startPlayerPos;

        public Action<Coin> CoinsAction;
        public Action<string> NotesAction;

        private void Awake()
        {
            statesPanel = FindObjectOfType<StatesPanel>(true);
            notesPanel = FindObjectOfType<NotesPanel>(true);
            touchPanel = FindObjectOfType<TouchPanel>(true);

            popups = new List<BasePopup>(GetComponentsInChildren<BasePopup>(true));
            popups.ForEach(_popup =>_popup.PopupShowAction = ActivatePopup);

#if UNITY_ANDROID
            androidBtns.SetActive(true);
            keyboardInput.SetActive(false);
#elif UNITY_STANDALONE
            androidBtns.SetActive(false);
            keyboardInput.SetActive(true);
#endif
        }

        public override void Show()
        {
            base.Show();

            Time.timeScale = 1;
            levelConfigs = GameInfo.Instance.LevelConfig;
            GameInfo.Instance.ResetLevelResult();
            coinsCount = 0;
            timeToDisplay = 0;
            statesPanel.TimerOn();
        }

        private void OnEnable()
        {
            activeLevel = FindObjectOfType<Level>(true);
            AddLevelData(activeLevel);

            statesPanel.ShowScores(coinsCount);
            statesPanel.ShowHealth(playerContr.PlayerHealth);
            timeToDisplay = 0;
        }

        public void AddLevelData(Level _level)
        {
            Debug.Log("AddLevelData: " + _level.LevelName);

            playerContr = _level.PlayerController;
            portal = _level.Portal;
            portal.IsPortalAction = ShowVictoryPopup;
            playerContr.PlayerDeathAction = OnLoose;
            playerContr.PlayerReturnAction = OnTryAgain;
            playerContr.ChangeHealthAction = ShowHealth;
            startPlayerPos = playerContr.transform.position;
            touchPanel.DragAction = _level.Rotator.DragDelta;

            _level.Coins.ForEach(_coin => _coin.OnCoinColected = CheckCoinsAmount);
            _level.Nameplates.ForEach(_nameplate => _nameplate.ActivateNameplate = ShowNotesPanel);
        }

        void ShowNotesPanel(string _frase)
        {
            notesPanel.ShowPanel.Invoke(_frase);
        }

        void ShowHealth(int _health) 
        {
            statesPanel.ShowHealth(_health);
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
                    _popTr.ReturnAction = ReturnLoosingHealth;
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
            Show();
        }

        void Restart() 
        {
            LoadGame();
            statesPanel.TimerOff();
        }
        
        void ReturnLoosingHealth(int _damage)
        {
            playerContr.AddHealth(_damage);
            playerContr.ReturnToStartPos(startPlayerPos);
            Show();
        }

        void OnLoose()
        {
            ActivatePopup(Popup.Loose);
            statesPanel.TimerOff();

            var _params = new Dictionary<string, object>();
            _params.Add("level", levelConfigs.LevelName);
            _params.Add("time", timeToDisplay);
            _params.Add("coins", coinsCount);

            var _result = AnalyticsEvent.Custom("result", _params);
            Debug.Log("AnalyticsEvent: " + _result);

            statesPanel.TimerOff();
        }

        void ShowSettingsPopup() 
        {
            ActivatePopup(Popup.Settings);        
        }

        void ShowVictoryPopup()
        {
            GameInfo.Instance.RegisterResult(coinsCount);
            ActivatePopup(Popup.Victory);

            var _params = new Dictionary<string, object>();

            _params.Add("level", levelConfigs.LevelName);
            _params.Add("time", timeToDisplay);

            var _result = AnalyticsEvent.Custom("result", _params);
            Debug.Log("AnalyticsEvent: " + _result);

            timeToDisplay = 0;
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

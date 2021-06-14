using System;
using System.Collections.Generic;
using CubePlatformer.Base;
using CubePlatformer.Core;
using TMPro;
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

        int health;
        int coinsCount = 0;
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

#if UNITY_ANDROID || UNITY_IOS
            androidBtns.SetActive(true);
            keyboardInput.SetActive(false);
#elif UNITY_STANDALONE 
            androidBtns.SetActive(false);
            keyboardInput.SetActive(true);
#endif
        }

        public void ShowAndLoadGame()
        {
            ShowScreen();

            levelConfigs = GameInfo.Instance.LevelConfig;
            GameInfo.Instance.ResetLevelResult();

            activeLevel = FindObjectOfType<Level>(true);
            activeLevel.GetLevelData();
            ConnectWithLevel(activeLevel);

            statesPanel.TimerOff();
            statesPanel.TimerOn();
            statesPanel.ShowScores(coinsCount);
            statesPanel.ShowHealth(health);

            Time.timeScale = 1;
            coinsCount = 0;
        }

        public void ConnectWithLevel(Level _level)
        {
            playerContr = _level.PlayerContr;
            portal = _level.Portal;
            portal.IsPortalAction = ShowVictoryPopup;
            playerContr.PlayerDeathAction = OnLoose;
            playerContr.PlayerReturnAction = OnTryAgain;
            playerContr.ChangeHealthAction = ShowHealth;
            health = playerContr.GetHealth();
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

            switch (_popup) 
            {
                case Popup.TryAgain:
                    var _popTr = activePopup.GetComponent<TryAgainPopup>();
                    _popTr.ReturnAction = ReturnChangeHealth;
                    _popTr.ReturnMinusHealthAction = ReturnChangeHealth;
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
            ShowScreen();
        }

        void Restart() 
        {
            LoadGame();
            statesPanel.TimerOff();
        }
        
        void ReturnChangeHealth(int _value)
        {
            playerContr.AddHealth(_value);
            playerContr.ReturnToStartPos(startPlayerPos);
            ShowScreen();
        }

        void OnLoose()
        {
            ActivatePopup(Popup.Loose);
            statesPanel.TimerOff();
            statesPanel.TimerOff();
        }

        void ShowSettingsPopup() 
        {
            ActivatePopup(Popup.Settings);        
        }

        void ShowVictoryPopup()
        {
            var _resultTime = GameInfo.Instance.Time;
            GameInfo.Instance.RegisterResult(coinsCount, _resultTime);
            ActivatePopup(Popup.Victory);
            GameInfo.Instance.LevelIndex += 1;

            AnaliticsMgr.Instance.AddResultParams(ParamsNames.Time, _resultTime);
            AnaliticsMgr.Instance.AddResultParams(ParamsNames.Level, levelConfigs.LevelName);
            AnaliticsMgr.Instance.AddResultAnalitics();
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

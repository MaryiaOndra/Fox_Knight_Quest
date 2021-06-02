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
        [SerializeField]
        TMP_Text healthTxt;


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
        float timeToDisplay;
        Vector3 startPlayerPos;

        public Action<Coin> CoinsAction;
        public Action<string> NotesAction;

        private void Awake()
        {
            statesPanel = FindObjectOfType<StatesPanel>(true);
            Debug.Log("statesPanel:   " + statesPanel);
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

        public void ShowAndLoadGame()
        {
            Show();

            levelConfigs = GameInfo.Instance.LevelConfig;
            GameInfo.Instance.ResetLevelResult();

            activeLevel = FindObjectOfType<Level>(true);
            activeLevel.GetLevelData();
            ConnectWithLevel(activeLevel);

            statesPanel.TimerOn();
            statesPanel.ShowScores(coinsCount);
            statesPanel.ShowHealth(health);

            Time.timeScale = 1;
            coinsCount = 0;
            timeToDisplay = 0;
        }

        public void ConnectWithLevel(Level _level)
        {
            healthTxt.text = "\n AddLevelData: " + _level.LevelName;

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
            healthTxt.text += "\n ShowHealth: " + _health;
            Debug.Log("ShowHealth: " + _health);
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
            Show();
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

using CubePlatformer.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace CubePlatformer
{
    public abstract class BasePopup : MonoBehaviour
    {
        //[SerializeField]
        //GameObject pausePopup;   
        //[SerializeField]
        //GameObject settingsPopup;        
        //[SerializeField]
        //GameObject loosePopup;        
        //[SerializeField]
        //GameObject tryAgainPopup;
        //[SerializeField]
        //GameObject victoryPopup;

        //public GameObject PausePopup => pausePopup;
        //public GameObject SettingsPopup => settingsPopup;
        //public GameObject LoosePopup => loosePopup;
        //public GameObject TryAgainPopup => tryAgainPopup;
        //public GameObject VictoryPopup => victoryPopup;

        public abstract Popup ScreenPopup { get; }

        public Action<Popup> PopupShowAction;

        public virtual void Show() 
        {
            SoundMgr.Instance.PlayBtnSound();
            gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        public void Hide()
        {
            SoundMgr.Instance.PlayBtnSound();
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public enum Popup
    {
        Pause,
        Settings,
        Loose,
        TryAgain,
        Victory
    }
}

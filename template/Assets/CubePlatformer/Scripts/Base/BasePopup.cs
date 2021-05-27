using System;
using UnityEngine;

namespace CubePlatformer
{
    public abstract class BasePopup : MonoBehaviour
    {
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

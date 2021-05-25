using CubePlatformer.Base;
using CubePlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class MenuScreen : BaseScreen
    {

        public const string Exit_Game = "Exit_Game";
        public const string Exit_Levels = "Exit_Levels";

        List<BasePopup> popups;
        BasePopup activePopup;

        void Awake()
        {
            popups = new List<BasePopup>(GetComponentsInChildren<BasePopup>(true));

            popups.ForEach(_popup =>
            {
                _popup.PopupShowAction = ActivatePopup;
            });
        }

        void ActivatePopup(Popup _popup)
        {
            activePopup = popups.Find(_p => _p.ScreenPopup == _popup);
            activePopup.Show();
        }

        public void OnGamePressed()
        {
            SoundMgr.Instance.PlayBtnSound();
            Exit(Exit_Game);
        }

        public void OnLevelsPressed()
        {
            SoundMgr.Instance.PlayBtnSound();
            Exit(Exit_Levels);
        }


        public void OnSettingsPressed()
        {
            ActivatePopup(Popup.Settings);
        }
    }
}

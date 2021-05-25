using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class SettingPopup : BasePopup
    {
        public override Popup ScreenPopup => Popup.Settings;

        public void OnBackPressed()
        {
            Hide();
        }

        public void OnMusicToggle(bool _value)
        {
            SoundMgr.Instance.MuteMusic(_value);
        }

        public void OnSoundToggle(bool _value)
        {
            SoundMgr.Instance.MuteSound(_value);
        }
    }
}


using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class SettingPopup : BasePopup
    {
        [SerializeField]
        Toggle SoundToggle;   
        [SerializeField]
        Toggle MusicToggle;

        public override Popup ScreenPopup => Popup.Settings;

        public override void Show()
        {
            base.Show();

            SoundToggle.isOn = AppPrefs.GetBool(PrefsKeys.Sound_);
            MusicToggle.isOn = AppPrefs.GetBool(PrefsKeys.Music_);
        }

        public void OnBackPressed()
        {
            Hide();
            Time.timeScale = 0;
        }

        public void OnMusicToggle(bool _value)
        {
            SoundMgr.Instance.MuteMusic(_value);
            AppPrefs.SetBool(PrefsKeys.Music_, _value);
        }

        public void OnSoundToggle(bool _value)
        {
            SoundMgr.Instance.MuteSound(_value);
            AppPrefs.SetBool(PrefsKeys.Sound_, _value);
        }
    }
}

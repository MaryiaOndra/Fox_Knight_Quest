using System;

namespace CubePlatformer
{
    public class PausePopup : BasePopup
    {
        public override Popup ScreenPopup => Popup.Pause;

        public Action BackPressedAction;
        public Action ReplyPressedAction;
        public Action MenuPressedAction;
        public Action SettingsPressedAction;


        public void OnBackPressed()
        {
            BackPressedAction.Invoke();
            Hide();
        }

        public void OnReplyPressed()
        {
            ReplyPressedAction.Invoke();
            Hide();
        }

        public void OnMenuPressed()
        {
            MenuPressedAction.Invoke();
            Hide();
        }

        public void OnSettingsPressed()
        {
            SettingsPressedAction.Invoke();
            Hide();
        }
    }
}

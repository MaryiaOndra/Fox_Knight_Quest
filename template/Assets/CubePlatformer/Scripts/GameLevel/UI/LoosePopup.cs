using System;

namespace CubePlatformer
{
    public class LoosePopup : BasePopup
    {
        public override Popup ScreenPopup => Popup.Loose;

        public Action RestartAction;
        public Action MenuPressedAction;

        public void OnRestartPressed()
        {
            RestartAction.Invoke();
            Hide();
        }

        public void OnMenuPressed()
        {
            MenuPressedAction();
            Hide();
        }
    }
}

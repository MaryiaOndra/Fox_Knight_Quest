using System;
using System.Collections;
using UnityEngine.Advertisements;

namespace CubePlatformer
{
    public class TryAgainPopup : BasePopup
    {
        public override Popup ScreenPopup => Popup.TryAgain;

        public Action ReturnMinusHealthAction;
        public Action ReturnAction;

        public void ReturnMinusHealth() 
        {
            ReturnMinusHealthAction.Invoke();
            Hide();
        }

        public void Return() 
        {
            if (Advertisement.IsReady("rewardedVideo"))
            {
                Advertisement.Show("rewardedVideo");
            }

            ReturnAction.Invoke();
            Hide();    
        }
    }
}

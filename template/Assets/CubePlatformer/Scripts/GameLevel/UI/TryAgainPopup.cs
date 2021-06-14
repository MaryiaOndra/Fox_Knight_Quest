using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class TryAgainPopup : BasePopup
    {
        const int HEALTH_DAMAGE = -1;
        const int HEALTH_BUFF = 1;

        [SerializeField]
        Button adsBtn;        
        
        [SerializeField]
        Button returndBtn;

        public override Popup ScreenPopup => Popup.TryAgain;

        public Action<int> ReturnMinusHealthAction;
        public Action<int> ReturnAction;

        private void OnEnable()
        {
            returndBtn.onClick.AddListener(ReturnMinusHealth);
#if UNITY_IOS
         adsBtn.onClick.AddListener(AdsMgr.Instance.ShowRewardedVideoAds);
#elif UNITY_ANDROID
          adsBtn.onClick.AddListener(AdsMgr.Instance.ShowRewardedVideoAds);
#elif UNITY_STANDALONE
            adsBtn.onClick.AddListener(ReturnWithAds);
#endif

         AdsMgr.Instance.AdsDidFinish = ReturnWithAds;
        }

        private void OnDisable()
        {
            returndBtn.onClick.RemoveListener(ReturnMinusHealth);
            adsBtn.onClick.RemoveListener(AdsMgr.Instance.ShowRewardedVideoAds);
        }

        public void ReturnMinusHealth() 
        {
            Hide();
            ReturnMinusHealthAction.Invoke(HEALTH_DAMAGE);
        }

        public void ReturnWithAds() 
        {
            Hide();
            ReturnAction.Invoke(HEALTH_BUFF);    
        }
    }
}

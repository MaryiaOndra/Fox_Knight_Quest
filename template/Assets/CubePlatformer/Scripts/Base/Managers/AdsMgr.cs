using CubePlatformer.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

namespace CubePlatformer
{
    public class AdsMgr : BaseManager<AdsMgr>
    {
        public const string REWARDED_PLACEMENT_ID = "rewardedVideo";

        bool isReady;
       

        public Action AdsDidFinish;

#if UNITY_IOS
         string adsId = "4145553";
#elif UNITY_ANDROID
        string adsId = "4145552";
#endif
        private void OnEnable()
        {
            Advertisement.Initialize(adsId, true);
        }

        public void ShowDefaultAd()
        {
            if (!Advertisement.IsReady())
            {
                Debug.Log("Ads not ready for default placement");
                return;
            }

            Advertisement.Show();
        }

        [Obsolete]
        public void ShowRewardedVideoAds()
        {
            if (!Advertisement.IsReady(REWARDED_PLACEMENT_ID))
            {
                Debug.Log(string.Format("Ads not ready for placement '{0}'", REWARDED_PLACEMENT_ID));
                return;
            }

            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(REWARDED_PLACEMENT_ID, options);
        }

        private void HandleShowResult(ShowResult result)
        {
            switch (result)
            {
                case ShowResult.Finished:
                    AdsDidFinish.Invoke();
                    break;
                case ShowResult.Skipped:
                    Debug.Log("The ad was skipped before reaching the end.");
                    break;
                case ShowResult.Failed:
                    Debug.LogError("The ad failed to be shown.");
                    break;
            }
        }
    }
}

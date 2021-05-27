using CubePlatformer.Core;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;


namespace CubePlatformer.Base
{
    public class CubePlatformerDirector : AppDirector
    {
        //void Awake()
        //{
        //    GameInfo.Instance.Setup();
        //    SceneManager.LoadScene("Menu");


        //}

        protected override void Awake()
        {
            base.Awake();

            string _adsId = string.Empty;

#if UNITY_IOS
            _adsId = "4145553";
#elif UNITY_ANDROID
            _adsId = "4145552";
#endif
            Advertisement.Initialize(_adsId);

            GameInfo.Instance.Setup();
            SceneManager.LoadScene("Menu");
        }
    }
}

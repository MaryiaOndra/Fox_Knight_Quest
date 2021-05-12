using CubePlatformer.Core;
using UnityEngine;

namespace CubePlatformer
{
    public class SettingsScreen : BaseScreen
    {
        public const string Exit_Back = "Exit_Back";

        [SerializeField]
        GameObject soundCross;    
        [SerializeField]
        GameObject musicCross;

        void Awake()
        {
            musicCross.SetActive(false);
            soundCross.SetActive(false);
        }

        public void OnBackPressed()
        {
            Exit(Exit_Back);
        }

        public void OnMusicToggle(bool _value) 
        {
            musicCross.SetActive(_value);
            SoundMgr.Instance.MuteMusic(!_value);
        }

        public void OnSoundToggle(bool _value) 
        {
            soundCross.SetActive(_value);
            SoundMgr.Instance.MuteSound(!_value);
        }
    }
}

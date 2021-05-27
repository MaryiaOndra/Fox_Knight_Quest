using CubePlatformer.Core;
using UnityEngine;
using UnityEngine.Audio;

namespace CubePlatformer
{
    public class SoundMgr : BaseManager<SoundMgr>
    {
        const float MUTE_VOLUME = -80f;
        const string MUSIC_PARAM_NAME = "MusicVolume";
        const string SOUND_PARAM_NAME = "SoundsVolume";

        float maxSoundVolume;
        float maxMusicVolume;

        [SerializeField]
        AudioMixer mixer;

        [SerializeField]
        AudioClip musicClip;      
        [SerializeField]
        AudioClip btnSoundClip;

        [SerializeField]
        AudioSource musicSource;
        [SerializeField]
        AudioSource soundSource;

        private void OnEnable()
        {
            mixer.GetFloat(SOUND_PARAM_NAME, out maxSoundVolume);
            mixer.GetFloat(MUSIC_PARAM_NAME, out maxMusicVolume);           
        }

        public void PlayMusic() 
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }

        public void PlayBtnSound() 
        {
            soundSource.PlayOneShot(btnSoundClip);
        }

        public void PlaySound(AudioClip _sound) 
        {
            soundSource.PlayOneShot(_sound);
        }

        public void MuteMusic(bool _value) 
        {
            mixer.SetFloat(MUSIC_PARAM_NAME, _value ? MUTE_VOLUME : maxMusicVolume);
        }

        public void MuteSound(bool _value) 
        {
            mixer.SetFloat(SOUND_PARAM_NAME, _value ? MUTE_VOLUME : maxSoundVolume);
        }
    }
}

using CubePlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace CubePlatformer
{
    public class SoundMgr : BaseManager<SoundMgr>
    {
        const float MUTE_VOLUME = -80f;

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
            mixer.SetFloat("MusicVolume", _value ? MUTE_VOLUME : 0);
        }

        public void MudeSound(bool _value) 
        {
            mixer.SetFloat("SoundsVolume", _value ? MUTE_VOLUME : 0);
        }
    }
}

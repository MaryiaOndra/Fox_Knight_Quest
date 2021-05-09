using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    [CreateAssetMenu(fileName = "My Nameplate Configs", menuName = "CubePlatformer/Cteate Nameplate Config")]
    public class NameplatesConfigs : ScriptableObject
    {
        [SerializeField]
        LevelContentId levelID;
        [SerializeField]
        string frase;
        [SerializeField]
        AudioClip clip;

        public string Frase => frase;
        public AudioClip Clip => clip;
    }
}

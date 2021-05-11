using CubePlatformer.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    [CreateAssetMenu(fileName = "My Levels Configs", menuName = "CubePlatformer/Cteate levels Config")]
    public class LevelsConfigs : ScriptableObject
    {
        [SerializeField]
        List<EachLevelConfigs> eachLevelConfigs;

       public List<EachLevelConfigs> EachLevelConfigs => eachLevelConfigs;
    }

    [Serializable]
    public class EachLevelConfigs
    {
        [SerializeField]
        LevelContentId id;
        [SerializeField]
        string levelName;
        [SerializeField]
        int coinsAmount;

        public LevelContentId Id => id;
        public string LevelName => levelName;
        public int CoinsAmount => coinsAmount;
        public bool IsGoingThoughPortal { get; set; }
    }
}

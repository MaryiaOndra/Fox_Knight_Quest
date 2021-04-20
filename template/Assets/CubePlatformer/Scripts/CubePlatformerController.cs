using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
using CubePlatformer.Base;

namespace CubePlatformer
{
    public class CubePlatformerController : MonoBehaviour
    {
        [SerializeField]
        List<LevelConfigs> eachLevelConfigs;

        public Action<int> ColectedAction { get; set; }
        public Action<bool> FinishLevelAction { get; set; }

        public List<LevelConfigs> EachLevelConfigs => eachLevelConfigs;

        public void StartGame(EachLevelConfigs _levelConfigs) 
        {
        
        }
    }

    [Serializable]
    public class LevelConfigs
    {
        //[SerializeField]
        //LevelContentId id;
        //[SerializeField]
        //int buildIndex;

        //public LevelContentId Id => id;
        //public int BuildIndex => buildIndex;
    }
}

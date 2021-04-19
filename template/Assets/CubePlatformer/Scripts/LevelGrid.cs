using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class LevelGrid : MonoBehaviour
    {
        [SerializeField]
        GameObject levelBtnPrefab;

        public Action<int> LevelSelected { get; private set; }

        public void ShowLevels(List<LevelState> _levelsStates) 
        {
        
        }
    }
}

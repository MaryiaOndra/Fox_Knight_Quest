using System.Collections;
using System.Collections.Generic;
using CubePlatformer.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer.Base
{
    public class CubePlatformerDirector : AppDirector
    {
        void Start()
        {

            GameInfo.Instance.Setup();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template.Core
{
    public abstract class AppDirector : MonoBehaviour
    {
        protected virtual void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

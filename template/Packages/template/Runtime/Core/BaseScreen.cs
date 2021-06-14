using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CubePlatformer.Core
{
    public abstract class BaseScreen : MonoBehaviour
    {
        public bool IsShow => gameObject.activeSelf;

        Action<Type, string> exitAction;

        public void Init(Action<Type, string> _exitAction) 
        {
            exitAction = _exitAction;
        }

        public virtual void ShowScreen() 
        {
            gameObject.SetActive(true);
            Debug.Log("SCREEN: " + gameObject.name);
        }

        public virtual void HideScreen() 
        {
            gameObject.SetActive(false);
        }

        protected void NextScreen(BaseScreen _screen) 
        {
            HideScreen();
            _screen.ShowScreen();
        }

        protected virtual void Exit(string _exitCode) 
        {
            exitAction.Invoke(GetType(), _exitCode);        
        }

    }
}
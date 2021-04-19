using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer.Core
{
    public abstract class SceneDirector : MonoBehaviour
    {
        Dictionary<Type, BaseScreen> screensDict;
        Stack<BaseScreen> screenStack;

        protected abstract void OnScreenExit(Type _screenType, string _exitCode);

        protected virtual void Start() 
        {
            screensDict = new Dictionary<Type, BaseScreen>();
            screenStack = new Stack<BaseScreen>();

            for (int i = 0; i < transform.childCount; i++)
            {
                var _screen = transform.GetChild(i).GetComponent<BaseScreen>();
                if (_screen) 
                {
                    if (_screen.IsShow)
                        throw new Exception($"{_screen.name} Screen must be disabled");

                    screensDict.Add(_screen.GetType(), _screen);
                    _screen.Init(OnScreenExit);
                }
            }
        }

        protected T SetCurrentScreen<T>() where T : BaseScreen 
        {
            BaseScreen _nextscreen = screensDict[typeof(T)];
            if (CurrentScreen)
            {
                CurrentScreen.Hide();
                if (BackScreen == _nextscreen)
                    screenStack.Pop();
                else
                    screenStack.Push(CurrentScreen);
            }

            CurrentScreen = _nextscreen;

            return CurrentScreen as T;
        }

        protected void ToBackScreen() 
        {
            var _nextScreen = screenStack.Pop();

            CurrentScreen.Hide();
            CurrentScreen = _nextScreen;
            CurrentScreen.Show();   
        }

        protected BaseScreen CurrentScreen { get; private set; }
        protected BaseScreen BackScreen => screenStack.Count > 0 ? screenStack.Peek() : null;
    }
}

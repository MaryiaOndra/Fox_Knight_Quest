using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer.Core
{
    public abstract class SceneDirector : MonoBehaviour
    {
        protected Dictionary<Type, BaseScreen> screensDict;
        Stack<BaseScreen> screenStack;
        protected BaseScreen CurrentScreen { get; private set; }
        protected BaseScreen BackScreen => screenStack.Count > 0 ? screenStack.Peek() : null;

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

#if UNITY_ANDROID || UNITY_IOS
            Cursor.visible = false;
#elif UNITY_STANDALONE
            Cursor.visible = true;
#endif

        }

        protected T SetCurrentScreen<T>() where T : BaseScreen 
        {
            BaseScreen _nextscreen = screensDict[typeof(T)];

            if (CurrentScreen)
            {
                CurrentScreen.HideScreen();

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

            CurrentScreen.HideScreen();
            CurrentScreen = _nextScreen;
            CurrentScreen.ShowScreen();   
        }       
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class KeyboardBtns : MonoBehaviour
    {
        public Action<BtnState> OnKeyboardInput;
      
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                OnKeyboardInput.Invoke(BtnState.MoveForward);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                OnKeyboardInput.Invoke(BtnState.MoveBack);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                OnKeyboardInput.Invoke(BtnState.MoveRight);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                OnKeyboardInput.Invoke(BtnState.MoveLeft);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                OnKeyboardInput.Invoke(BtnState.Jump);        
            }

            if (Input.GetKeyUp(KeyCode.W) ||
                Input.GetKeyUp(KeyCode.S) ||
                Input.GetKeyUp(KeyCode.D) || 
                Input.GetKeyUp(KeyCode.A) || 
                Input.GetKeyUp(KeyCode.Space))
            {
                OnKeyboardInput.Invoke(BtnState.None);
            }

        }
    }
}

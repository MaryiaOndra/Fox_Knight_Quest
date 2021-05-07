using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class KeyboardInput : MonoBehaviour
    {
        void Update()
        {
            VirtualInputManager.Instance.MoveVertical = Input.GetAxis("Vertical");
            VirtualInputManager.Instance.MoveHorizontal = Input.GetAxis("Horizontal");

            VirtualInputManager.Instance.Attack = Input.GetKeyDown(KeyCode.F) ? true : false;
            VirtualInputManager.Instance.Defend = Input.GetKey(KeyCode.C) ? true : false;
        }
    }
}

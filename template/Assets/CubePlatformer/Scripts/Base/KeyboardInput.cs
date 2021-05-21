using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
#if UNITY_STANDALONE
    public class KeyboardInput : MonoBehaviour
    {
        void Update()
        {
            VirtualInputManager.Instance.MoveVertical = Input.GetAxisRaw("Vertical");
            VirtualInputManager.Instance.MoveHorizontal = Input.GetAxisRaw("Horizontal");
            VirtualInputManager.Instance.Attack = Input.GetKeyDown(KeyCode.F) ? true : false;
            VirtualInputManager.Instance.Defend = Input.GetKey(KeyCode.C) ? true : false;
        }
    }
#endif
}

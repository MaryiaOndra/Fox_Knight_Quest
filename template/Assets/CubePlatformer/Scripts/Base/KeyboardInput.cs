using UnityEngine;

namespace CubePlatformer
{
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
}

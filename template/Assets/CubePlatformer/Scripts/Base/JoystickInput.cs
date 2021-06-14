using UnityEngine;

namespace CubePlatformer
{  

    public class JoystickInput : MonoBehaviour
    {
        Joystick joystick;

        bool DefendState { get; set; }
        bool AttackState { get; set; }

        private void Awake()
        {
            joystick = FindObjectOfType<Joystick>();
        }
        void Update()
        {
            VirtualInputManager.Instance.MoveVertical = joystick.Vertical;
            VirtualInputManager.Instance.MoveHorizontal = joystick.Horizontal;
            VirtualInputManager.Instance.Attack = AttackState;
            VirtualInputManager.Instance.Defend = DefendState;

            AttackState = false;
        }

        public void DefendInput(bool _btnState)
        {
            DefendState = _btnState;
        }

        public void AttackInput() 
        {
            AttackState = true;
        }
    }
}

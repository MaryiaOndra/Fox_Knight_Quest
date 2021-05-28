using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class ButtonsInput : MonoBehaviour
    {
        bool DefendState { get; set; }
        bool AttackState { get; set; }

        private void Update()
        {
            VirtualInputManager.Instance.Attack = AttackState;
            VirtualInputManager.Instance.Defend = DefendState;
            AttackState = false;
        }

        public void VerticalInput(int _speed)
        {
            VirtualInputManager.Instance.MoveVertical = _speed;
        }

        public void HorizontalInput(int _speed)
        {
            VirtualInputManager.Instance.MoveHorizontal = _speed;
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

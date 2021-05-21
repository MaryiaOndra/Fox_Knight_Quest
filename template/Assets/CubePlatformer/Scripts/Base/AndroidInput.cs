using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
   

    public class AndroidInput : MonoBehaviour
    {
        Joystick joystick;

        bool DefendState { get; set; }
        bool AttackState { get; set; }

        private void Awake()
        {
            joystick = FindObjectOfType<Joystick>();
        }

#if UNITY_ANDROID

        void Update()
        {
            VirtualInputManager.Instance.MoveVertical = joystick.Vertical;
            VirtualInputManager.Instance.MoveHorizontal = joystick.Horizontal;

            VirtualInputManager.Instance.Attack = AttackState;
            VirtualInputManager.Instance.Defend = DefendState;
        }
#endif

        public void DefendInput(bool _btnState)
        {
            DefendState = _btnState;
        }

        public void AttackInput() 
        {
            StartCoroutine(AttackBool());
        }

        IEnumerator AttackBool ()
        {
            AttackState = true;
            yield return new WaitForEndOfFrame();
            AttackState = false;
        }
    }
}

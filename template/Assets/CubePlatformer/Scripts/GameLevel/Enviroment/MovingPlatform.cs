using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class MovingPlatform : MonoBehaviour
    {
        static readonly int INT_STATE = Animator.StringToHash("MoveState");

        [SerializeField]
        MoveStates moveState;

        Animator bridgeAnimator;

        private void Awake()
        {
            bridgeAnimator = GetComponent<Animator>();

            bridgeAnimator.SetInteger(INT_STATE, (int)moveState);
        }

        private void OnTriggerStay(Collider _collision)
        {
            if (_collision.gameObject.GetComponent<PlayerController>())
            {
                _collision.gameObject.transform.SetParent(transform);
            }
        }

        private void OnTriggerExit(Collider _collision)
        {
            if (_collision.gameObject.GetComponent<PlayerController>())
            {
                _collision.gameObject.transform.SetParent(null);
            }
        }
    }

    enum MoveStates 
    {
        None = 0,
        Down = 1,
        Left = 2,
        Right = 3,
        DoubleLeft = 4,
        DoubleRight = 5,
        DoubleForward = 6,
        DoubleBack = 7
    }
}

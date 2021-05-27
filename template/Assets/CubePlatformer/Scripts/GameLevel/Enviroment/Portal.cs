using System;
using UnityEngine;

namespace CubePlatformer
{
    public class Portal : MonoBehaviour
    {
        public Action IsPortalAction;

        void OnTriggerExit(Collider other)
        {
            IsPortalAction.Invoke();
        }

        public void ActivateVictoryPortal() 
        {
            gameObject.SetActive(true);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Portal : MonoBehaviour
    {
        [SerializeField]
        GameObject portalNameplate;

        public Action PortalAction;

        void OnTriggerExit(Collider other)
        {
            PortalAction.Invoke();
        }

        public void ActivatePortal() 
        {
            gameObject.SetActive(true);
            
            if (portalNameplate != null)
                portalNameplate.SetActive(true);
        }
    }
}

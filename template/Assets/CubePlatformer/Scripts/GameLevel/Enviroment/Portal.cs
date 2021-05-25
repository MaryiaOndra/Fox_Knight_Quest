using CubePlatformer.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class Portal : MonoBehaviour
    {
        //[SerializeField]
        //GameObject portalNameplate;

        public Action IsPortalAction;

        void OnTriggerExit(Collider other)
        {
            IsPortalAction.Invoke();
        }

        public void ActivateVictoryPortal() 
        {
            gameObject.SetActive(true);
            
            //if (portalNameplate != null)
            //    portalNameplate.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubePlatformer
{
    public class TryAgainPopup : MonoBehaviour
    {
        public void Show()
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }

        public void Hide() 
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}

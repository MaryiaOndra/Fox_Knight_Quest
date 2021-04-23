using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CubePlatformer
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        Slider screenSlider;
        [SerializeField]
        Button up;
        [SerializeField]
        Button down;
        [SerializeField]
        Button left;
        [SerializeField]
        Button right;

        LevelController levelController;

        public void Setup()
        {
            levelController = FindObjectOfType<LevelController>();
            Debug.Log("FindObjectOfType<LevelController>();   " + (levelController != null));

            //TODO: Itsnot working - change way of loading level
            levelController.AddUIDependency(screenSlider);
        }

        public void NewMethod() 
        {
        
        }

        private void Update()
        {

        }
    }
}

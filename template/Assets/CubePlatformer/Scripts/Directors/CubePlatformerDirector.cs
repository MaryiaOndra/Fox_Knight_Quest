using CubePlatformer.Core;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;


namespace CubePlatformer.Base
{
    public class CubePlatformerDirector : AppDirector
    {
        void Start()
        {            
            GameInfo.Instance.Setup();
            SceneManager.LoadScene("Menu");
        }
    }
}

using CubePlatformer.Core;
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

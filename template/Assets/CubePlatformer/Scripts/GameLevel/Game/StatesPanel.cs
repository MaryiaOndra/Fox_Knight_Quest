using TMPro;
using UnityEngine;

namespace CubePlatformer
{
    public class StatesPanel : MonoBehaviour
    {
        [SerializeField]
        TMP_Text scoreTxt;
        [SerializeField]
        TMP_Text healthTxt;

        public void ShowScores(int _score) 
        {
            scoreTxt.text = "x "+ _score.ToString();
        }
        public void ShowHealth(int _health) 
        {
            healthTxt.text = "x " + _health.ToString();
        }
    }
}

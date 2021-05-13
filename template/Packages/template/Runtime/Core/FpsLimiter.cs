using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLimiter : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}

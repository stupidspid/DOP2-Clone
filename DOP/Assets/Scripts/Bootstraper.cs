using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    private void OnEnable()
    {
        Application.targetFrameRate = 120;
    }
}

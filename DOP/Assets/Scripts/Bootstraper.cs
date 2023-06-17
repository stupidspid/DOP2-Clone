using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    private void OnEnable()
    {
        Application.targetFrameRate = 120;
    }
}

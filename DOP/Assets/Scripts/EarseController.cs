using UnityEngine;

public class EarseController : MonoBehaviour, IEarsable
{
    [SerializeField] private SpriteMask mask;
    
    public void Begin(Vector3 position)
    {
        mask.enabled = true;
        transform.position = position;
    }

    public void Stop()
    {
        mask.enabled = false;
    }
}

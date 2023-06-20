using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private EarseController earse;
    [SerializeField] private int earsesAmount;
    [SerializeField] private Transform container;
    [SerializeField] private float smoothSpeed = 10;

    private List<EarseController> earses = new List<EarseController>();
    private Camera _camera;
    private EarseController _earse;
    private int _currentEarseIndex;
    private Vector3 currentVelocity;

    private void Start()
    {
        _camera = Camera.main;
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < earsesAmount; i++)
        {
            var newEarse = Instantiate(earse, container);
            earses.Add(newEarse);
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var spawnPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0;
            var smoothPos = spawnPosition;
            if (_currentEarseIndex > 0)
            {
                smoothPos = Vector3.SmoothDamp(earses[_currentEarseIndex-1].transform.position,
                    spawnPosition, ref currentVelocity, Time.deltaTime * smoothSpeed);
            }
            earses[_currentEarseIndex].Begin(smoothPos);
            _currentEarseIndex++;
        }
        else
        {
            foreach (var t in earses)
            {
                t.Stop();
            }

            _currentEarseIndex = 0;
        }
    }
}

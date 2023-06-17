using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private EarseController earse;
    [SerializeField] private int earsesAmount;
    [SerializeField] private Transform container;

    private List<EarseController> earses = new List<EarseController>();
    private Camera _camera;
    private EarseController _earse;
    private int _currentEarseIndex;

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
            earses[_currentEarseIndex].Begin(spawnPosition);
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

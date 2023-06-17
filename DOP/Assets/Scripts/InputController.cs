using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private EarseController earse;
    [SerializeField] private Scratch scratch;
    
    private Camera _camera;
    private EarseController _earse;

    private void OnEnable()
    {
        _camera = Camera.main;
        Spawn();
    }

    public void Spawn()
    {
        _earse = Instantiate(earse);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var spawnPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0;
            _earse.Begin(spawnPosition);
            scratch.AssignScreenAsMask();
        }
        else
        {
            _earse.Stop();
            Scratch.I.Stop();
        }
    }
}

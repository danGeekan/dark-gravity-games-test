using System;
using System.Collections;
using UnityEngine;

public class SpawnController
{
    private readonly ICoroutineRunner _context;
    private readonly ISpawner _spawner;
    private float _interval;
    private Action _onChangeState;
    private Coroutine _spawnCoroutine;
    
    public SpawnController(ICoroutineRunner context, ISpawner spawner)
    {
        _context = context;
        _spawner = spawner;
    }

    public void Start(float interval, Action onStartSpawn)
    {
        _interval = interval;
        _spawnCoroutine = _context.StartCoroutine(SpawnRoutine());
        _onChangeState = onStartSpawn;

        _onChangeState?.Invoke();
    }

    public void Stop()
    {
        if (_spawnCoroutine != null)
            _context.StopCoroutine(_spawnCoroutine);
        
        _onChangeState?.Invoke();
    }

    private IEnumerator SpawnRoutine()
    {
        var wait = new WaitForSeconds(_interval);
        while (true)
        {
           bool isSpawned = _spawner.Spawn();
           
           if (!isSpawned) Stop();
               
            yield return wait;
        }
    }
}
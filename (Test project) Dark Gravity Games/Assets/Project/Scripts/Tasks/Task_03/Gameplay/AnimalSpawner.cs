using UnityEngine;
using System.Collections.Generic;

public class AnimalSpawner : ISpawner
{
    private readonly SpawnSettings _settings;
    private readonly Transform _spawnPoint;
    private readonly Transform _container;
    private readonly Camera _camera;
    private readonly SpawnPointGenerator _generator;
    private readonly List<GameObject> _spawnedAnimals;
    private readonly HashSet<Vector3> _spawnedPositions;

    public AnimalSpawner(SpawnSettings settings,  SpawnPointGenerator generator, Transform container, Camera camera, Transform spawnPoint)
    {
        _settings = settings;
        _generator = generator;
        _container = container;
        _camera = camera;
        _spawnPoint = spawnPoint;

        _spawnedAnimals = new List<GameObject>();
        _spawnedPositions = new HashSet<Vector3>();
    }

    public bool Spawn()
    {
        
        if (!_generator.TryGetSpawnPosition(out Vector3 position, _spawnPoint.position, _spawnedPositions))
        {
            Debug.LogWarning("No free position found");
            return false;
        }
        
        int index = Random.Range(0, _settings.Animals.Length);
        Quaternion rotation = LookAtCamera(position);

        var animal = Object.Instantiate(_settings.Animals[index], position, rotation, _container);
        
        _spawnedAnimals.Add(animal);
        _spawnedPositions.Add(position);
        return true;
    }

    private Quaternion LookAtCamera(Vector3 position)
    {
        var dir = _camera.transform.position - position;

        dir.y = 0;

        return Quaternion.LookRotation(dir);
    }

    public void Clear()
    {
        _spawnedAnimals.ForEach(Object.Destroy);
        
        _spawnedAnimals.Clear();
        _spawnedPositions.Clear();
    }
}
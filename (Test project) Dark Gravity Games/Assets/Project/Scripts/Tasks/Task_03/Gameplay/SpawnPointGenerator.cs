using UnityEngine;
using System.Collections.Generic;

public class SpawnPointGenerator
{
    private readonly SpawnSettings _settings;
    private readonly SpawnPointValidator _validator;
    private HashSet<Vector3> _usedPoints;

    public SpawnPointGenerator(SpawnSettings settings, SpawnPointValidator validator)
    {
        _settings = settings;
        _validator = validator;
    }

    public bool TryGetSpawnPosition(out Vector3 position, Vector3 spawnPoint, HashSet<Vector3> usedPoints)
    {
        _usedPoints = usedPoints;
        var result = TryGeneratePointsWithAttempts(spawnPoint);
        if (result.HasValue)
        {
            position = result.Value;
            return true;
        }

        position = default;
        return false;
    }

    private Vector3? TryGeneratePointsWithAttempts(Vector3 center)
    {
        int attempts = 0;
        while (attempts <= _settings.SpawnAttempts)
        {
            var point = RandomPointOnTile(center);
            if (_validator.IsValid(point, _usedPoints, _settings.MinSpawnDistance))
                return point;

            attempts++;
        }

        return null;
    }

    private Vector3 RandomPointOnTile(Vector3 center)
    {
        float offsetX = Random.Range(-_settings.SpawnRadius, _settings.SpawnRadius);
        float offsetZ = Random.Range(-_settings.SpawnRadius, _settings.SpawnRadius);

        return new Vector3(
            Mathf.Round((center.x + offsetX) * 100f) / 100f,
            center.y,
            Mathf.Round((center.z + offsetZ) * 100f) / 100f
        );
    }
}
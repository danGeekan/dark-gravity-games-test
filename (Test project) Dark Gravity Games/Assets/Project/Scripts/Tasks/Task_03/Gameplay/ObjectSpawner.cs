using System;

public class ObjectSpawner
{
    private readonly SpawnSettings _spawnSettings;
    private readonly SpawnController _controller;
    
    public ObjectSpawner(SpawnSettings settings, SpawnController controller)
    {
        _spawnSettings = settings;
        _controller = controller;
    }

    public void Spawn(Action onStartSpawn)
    {
        _controller.Start(_spawnSettings.SpawnTimeInterval, onStartSpawn);
    }

    public void Stop()
    {
        _controller.Stop();
    }
}
using UnityEngine;
using Zenject;

public class ObjectSpawnInstaller : MonoInstaller
{
    [SerializeField] private SpawnSettings spawnSettings;
    [SerializeField] private Transform animalSpawnContainer;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform spawnPoint;
    public override void InstallBindings()
    {
        //Settings
        Container.Bind<SpawnSettings>().FromInstance(spawnSettings).AsSingle();

        //Services
        Container.Bind<ObjectSpawner>().AsSingle();
        Container.Bind<SpawnPointGenerator>().AsSingle();
        Container.Bind<SpawnPointValidator>().AsSingle();
        Container.Bind<SpawnController>().AsSingle();
        Container.Bind<ISpawner>().To<AnimalSpawner>().AsSingle().WithArguments(animalSpawnContainer, mainCamera, spawnPoint);
    }
}

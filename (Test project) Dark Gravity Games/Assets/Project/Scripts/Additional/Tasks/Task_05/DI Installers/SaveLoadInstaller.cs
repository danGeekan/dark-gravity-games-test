using UnityEngine;
using Zenject;

public class SaveLoadInstaller : MonoInstaller
{
    [SerializeField] private GameSaveManager gameSaveManager;
    [SerializeField] private GroupMover groupMover;
    
    public override void InstallBindings()
    {
        //Managers
        Container.Bind<GameSaveManager>().FromInstance(gameSaveManager).AsSingle();
        Container.Bind<GroupMover>().FromInstance(groupMover).AsSingle();
        
        //Services
        Container.Bind<ISave>().To<SavePosService>().AsSingle();
        Container.Bind<ILoad>().To<LoadPosService>().AsSingle();
    }
}
using UnityEngine;
using Zenject;

public class CustomCoroutineInstaller : MonoInstaller
{
    [SerializeField] private CoroutineRunner coroutineRunner;
    public override void InstallBindings()
    {
        Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromInstance(coroutineRunner).AsSingle();
    }
}
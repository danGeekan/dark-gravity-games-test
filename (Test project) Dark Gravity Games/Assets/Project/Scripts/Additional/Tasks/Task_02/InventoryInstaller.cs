using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField] private ItemsList itemsList;
    public override void InstallBindings()
    {
        Container.Bind<ItemsList>().FromInstance(itemsList).AsSingle();
    }
}
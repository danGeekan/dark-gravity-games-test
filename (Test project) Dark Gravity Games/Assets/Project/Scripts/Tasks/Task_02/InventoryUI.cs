using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    [SerializeField] private VisualTreeAsset itemTemplate; 
    private VisualElement _inventoryContainer;

    private ItemsList _itemsList;
    [Inject]
    private void Construct(ItemsList itemsList)
    {
        _itemsList = itemsList;
    }
    
    private void OnEnable()
    {
       Init();
       InitSpawn();
    }

    private void Init()
    {
        var root = uiDocument.rootVisualElement;

        _inventoryContainer = root.Q<VisualElement>("items-container");
        
        var addButton = root.Q<Button>("add-button");
        addButton.clicked += AddRandomItem;
    }

    private void InitSpawn()
    {
        foreach (var item in _itemsList.Items)
            AddItem(item);
    }
    
    private void AddRandomItem()
    {
        int num = Random.Range(0, _itemsList.Items.Count);
        AddItem(_itemsList.Items[num]);
    }
    
    public void AddItem(Item data)
    {
        var itemElement = itemTemplate.Instantiate();
        itemElement.Q<Label>("item-name").text = data.Label;
        itemElement.Q<VisualElement>("item-icon").style.backgroundImage = new StyleBackground(data.Image);

        var removeButton = itemElement.Q<Button>("remove-button");
        removeButton.clicked += () => RemoveItem(itemElement);

        _inventoryContainer.Add(itemElement);
    }

    private void RemoveItem(VisualElement itemElement)
    {
        _inventoryContainer.Remove(itemElement);
    }
}
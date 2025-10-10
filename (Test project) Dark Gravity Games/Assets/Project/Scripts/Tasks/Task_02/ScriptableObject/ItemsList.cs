using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsList", menuName = "Scriptable Objects/Task_02/ItemsList")]
public class ItemsList : ScriptableObject
{
    [SerializeField] private List<Item> items;
    
    public List<Item> Items => items;
}

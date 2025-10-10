using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] private Sprite image;
    [SerializeField] private string label;

    #region Public values

    public Sprite Image => image;
    public string Label => label;

    #endregion
}
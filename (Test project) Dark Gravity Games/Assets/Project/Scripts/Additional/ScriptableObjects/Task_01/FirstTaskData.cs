using UnityEngine;

[CreateAssetMenu(fileName = "FirstTaskData", menuName = "Scriptable Objects/Additional/FirstTaskData")]
public class FirstTaskData : ScriptableObject
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float heightSpeed;

    #region MyRegion

    public float MoveSpeed => moveSpeed;
    public float HeightSpeed => heightSpeed;

    #endregion
}

using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSettings", menuName = "Scriptable Objects/Task_03/SpawnSettings")]
public class SpawnSettings : ScriptableObject
{
    [Header("For Task")]
    [SerializeField] private GameObject[] animals;
    [SerializeField] private float spawnTimeInterval;
    [SerializeField] private float spawnRadius;

    [Header("Additional")] 
    [SerializeField] private float minSpawnDistance;
    [SerializeField]private int spawnAttempts;

    #region Public values

    public GameObject[] Animals => animals; 
    public float SpawnTimeInterval => spawnTimeInterval;
    public float SpawnRadius => spawnRadius;
    public float MinSpawnDistance => minSpawnDistance;
    public int SpawnAttempts => spawnAttempts;
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaveSettings : ScriptableObject
{
    [Tooltip("Highest Level influenced by these settings.")]
    public int HighestLevelToCover;
    public int MinWaveDuration;
    public int MaxWaveDuration;
    public EnemyToSpawn[] EnemiesToSpawn;

    // bosses or not
    // boss types
}

// wrapper
[System.Serializable]
public class EnemyToSpawn
{
    public EnemyType EnemyType;
    public GameObject Prefab;

    public float MinSpawnInterval;
    public float MaxSpawnInterval;
}
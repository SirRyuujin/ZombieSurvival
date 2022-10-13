using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// object pooling?
// mergin all spawners into one object?
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private FloatVariable _spawnInterval;
    [SerializeField] private FloatVariable _initialSpawnDelay;
    [SerializeField] private Camera _cam;

    private void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.         
        InvokeRepeating("Spawn", _initialSpawnDelay.Value, _spawnInterval.Value);
    }

    private void Spawn()
    {
        // set spawn position based on player's position
        Vector3 spawnPosition = GetValidSpawnPoint();

        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetValidSpawnPoint()
    {
        // 1. Distance between cam viewport and world boundries
        // if > 0 => spawn enemy
        // else
        // check on other sides | spawn in cam view

        // 2. Set spawn points

        return _cam.ViewportToWorldPoint(new Vector3(1.1f, 0.5f, 10));
    }
}
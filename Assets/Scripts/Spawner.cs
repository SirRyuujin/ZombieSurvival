using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// object pooling?
// mergin all spawners into one object?
public class Spawner : MonoBehaviour
{
    public float LeftCord;
    public float RightCord;
    public float TopCord;
    public float BottomCord;

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
        Vector3 spawnPosition = GetValidSpawnPoint();

        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetValidSpawnPoint()
    {
        float x;
        float y;
        Vector3 spawnPoint = new Vector3(0, 0, 10);
        bool isValid = false;

        do
        {
            y = Random.Range(0f, 1f);

            if (Random.Range(0, 2) == 0)
                x = Random.Range(-0.5f, -0.1f);
            else
                x = Random.Range(1.1f, 1.5f);

            spawnPoint = _cam.ViewportToWorldPoint(new Vector3(x, y, 10));
            if (spawnPoint.x >= LeftCord && spawnPoint.x <= RightCord)
                if (spawnPoint.y <= TopCord && spawnPoint.y >= BottomCord)
                    isValid = true;
        } while (!isValid);

        return spawnPoint;
    }
}
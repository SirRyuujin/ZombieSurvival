using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersController : MonoBehaviour
{
    public Spawner[] Spawners;
    public WaveSettings[] WaveSettings;
    public IntVariable SettingsID;

    public void ToogleSpawners()
    {
        for (int i = 0; i < Spawners.Length; i++)
        {
            Spawners[i].enabled = false;
            for (int j = 0; j < WaveSettings[SettingsID.Value].EnemiesToSpawn.Length; j++)
            {
                var tmp = WaveSettings[SettingsID.Value].EnemiesToSpawn[j];
                if (tmp.EnemyType == Spawners[i].EnemyType)
                {
                    Spawners[i].enabled = true;
                    Spawners[i].ApplyWaveSettings(Random.Range(tmp.MinSpawnInterval, tmp.MaxSpawnInterval));
                    break;
                }
            }
        }        
    }
}
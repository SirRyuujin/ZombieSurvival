using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadSystem : MonoBehaviour
{
    [Header("References")]
    public IntVariable MaxHp;
    public IntVariable Ammo;
    public IntVariable Damage;
    public FloatVariable MoveSpeed;
    public FloatVariable ReloadTime;
    public FloatVariable FireRate;

    private void Start()
    {
        LoadData();
    }

    [ContextMenu("SAVE")]
    public void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GameData.data";

        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(MaxHp.Value, Ammo.Value, Damage.Value, MoveSpeed.Value, ReloadTime.Value, FireRate.Value);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    [ContextMenu("LOAD")]
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/GameData.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;

            stream.Close();

            SetLoadedData(data);
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
        }
    }

    private void SetLoadedData(GameData data)
    {
        MaxHp.Value = data.MaxHp;
        Ammo.Value = data.Ammo;
        Damage.Value = data.Damage;
        MoveSpeed.Value = data.MoveSpeed;
        ReloadTime.Value = data.ReloadTime;
        FireRate.Value = data.FireRate;

        Debug.Log("Data loaded!");
    }
}
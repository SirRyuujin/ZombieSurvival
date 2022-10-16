using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


// add Variable referenves
// arrays of them
// every time new Variable appears - add to the system

public class SaveLoad
{
    public void SaveData()
    {
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string path = Application.persistentDataPath + "/GameData.data";

    //    FileStream stream = new FileStream(path, FileMode.Create);

    ////    CharacterData charData = new CharacterData(character);

    //    formatter.Serialize(stream, charData);
    //    stream.Close();
    }

    public void LoadData()
    {
        //string path = Application.persistentDataPath + "/GameData.data";

        //if (File.Exists(path))
        //{
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    FileStream stream = new FileStream(path, FileMode.Open);

        ////    CharacterData data = formatter.Deserialize(stream) as CharacterData;

        //    stream.Close();

        //    return data;
        //}
        //else
        //{
        //    Debug.LogError("Error: Save file not found in " + path);
        //    return null;
        //}
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class FileManipulator
{
    public void CreateBinnaryFile<T>(T content, string name)
    {
        using (FileStream fs = File.Create(Path.Combine(Application.persistentDataPath, name)))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, content);
        }
    }


    public T ReadBinnaryFile<T>(string name)
    {
        T toReturn = default(T);
        using (FileStream fs = File.OpenRead(Path.Combine(Application.persistentDataPath, name)))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            toReturn = (T)formatter.Deserialize(fs);
        }

        return toReturn;
    }


    public string GetTextFileContent(string path)
    {
        var asset = Resources.Load<TextAsset>(path);

        return asset.text;
    }


    public GameObject GetGameObject(string path)
    {
        return Resources.Load<GameObject>(path);
    }
}

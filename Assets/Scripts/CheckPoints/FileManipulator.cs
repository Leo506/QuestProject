using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FileManipulator : IFileManipulator
{
    public void CreateBinnaryFile<T>(T content, string name)
    {
        using (FileStream fs = File.Create(Path.Combine(Application.persistentDataPath, name)))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, content);
        }
    }

    public T LoadBinnaryFile<T>(string name)
    {
        if (!File.Exists(Path.Combine(Application.persistentDataPath, name)))
            return default(T);

        T toReturn = default(T);
        using (FileStream fs = File.OpenRead(Path.Combine(Application.persistentDataPath,name)))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            toReturn = (T)formatter.Deserialize(fs);
        }

        return toReturn;
    }
}

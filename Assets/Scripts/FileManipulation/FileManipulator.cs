using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class FileManipulator : IFileManipulator
{
    private Initialisierer initialisierer;
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

    public void GetTextFileContent(string name, Action<string> methodOnLoad)
    {
        if (initialisierer == null)
        {
            initialisierer = GameObject.FindObjectOfType<Initialisierer>();
            if (initialisierer == null)
            {
                var gameObj = new GameObject();
                initialisierer = gameObj.AddComponent<Initialisierer>();
            }
        }
        initialisierer.StartCoroutine(LoadFileContent(name, methodOnLoad));
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

    private IEnumerator LoadFileContent(string name, Action<string> methodOnLoad)
    {
        var path = Application.streamingAssetsPath + name;
        WWW www = new WWW(path);

        yield return www;

        string toReturn = www.text;

        methodOnLoad(toReturn);
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

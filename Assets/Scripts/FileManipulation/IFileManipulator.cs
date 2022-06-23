using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFileManipulator
{
    void CreateBinnaryFile<T>(T content, string name);
    T LoadBinnaryFile<T>(string name);

    void GetTextFileContent(string name, Action<string> methodOnLoad);
}

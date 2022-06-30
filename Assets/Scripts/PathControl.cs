using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/Path", fileName = "Path control asset")]
public class PathControl : ScriptableObject
{
    [SerializeField] private string _pathToCutScenes;
    public string PathToCutScenes { get => _pathToCutScenes; }

    [SerializeField] private string _pathToDialogs;
    public string PathToDialogs { get => _pathToDialogs; }

    [SerializeField] private string _pathToMiniGames;
    public string PathToMiniGames { get => _pathToMiniGames; }

    [SerializeField] private string _pathToQuests;
    public string PathToQuests { get => _pathToQuests; }
}

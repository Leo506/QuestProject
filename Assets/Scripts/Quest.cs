using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO подумать, можно ли сделать структурой
[System.Serializable]
public class Quest
{
    public string Title;
    public string Description;
    public int id;
    [SerializeReference] public Conditions.Condition Condition;
}

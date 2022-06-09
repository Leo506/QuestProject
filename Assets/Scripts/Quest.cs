using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState
{
    NONE,
    IN_PROGRESS,
    PASS
}

// TODO ��������, ����� �� ������� ����������
[System.Serializable]
public class Quest
{
    public string Title;
    public string Description;
    public int id;
    public int GiverID;
    public QuestState State;
    [SerializeReference] public Conditions.Condition Condition;
}

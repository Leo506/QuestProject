using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState
{
    NONE,
    IN_PROGRESS,
    PASS
}

// TODO подумать, можно ли сделать структурой
[System.Serializable]
public class Quest
{
    public string Title;
    public string Description;
    public int id;
    public int GiverID;

    private QuestState _state;
    public QuestState State
    {
        get => _state;
        set
        {
            _state = value;
            OnStateChange?.Invoke(id, _state);
        }
    }
    [SerializeReference] public Conditions.Condition Condition;

    public static event System.Action<int, QuestState> OnStateChange;

    public void Start()
    {
        Condition.OnStart();

        Condition.OnPass += () => State = QuestState.PASS;
    }
}

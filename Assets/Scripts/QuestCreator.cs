using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCreator : MonoBehaviour
{
    [Header("Создание квеста")]
    [SerializeField] string Title;
    [SerializeField] string Description;
    [SerializeField] int id;
    [SerializeReference] public Conditions.Condition condition = new Conditions.MailCondition();
}

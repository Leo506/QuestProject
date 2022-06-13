using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialisierer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(QuestSystem.QuestManager.currentQuestID);   
    }
}

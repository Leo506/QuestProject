using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour, IUsable
{
    public void Use()
    {
        Debug.Log("Quest is given");
    }
}

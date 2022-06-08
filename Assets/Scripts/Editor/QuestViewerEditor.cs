using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CustomEditor(typeof(QuestViewer))]
public class QuestViewerEditor : Editor
{
    SerializedProperty idProperty;
    SerializedProperty questProperty;

    private void OnEnable()
    {
        idProperty = serializedObject.FindProperty("questID");
        questProperty = serializedObject.FindProperty("quest");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(idProperty);

        var id = idProperty.intValue;

        if (!File.Exists(Application.streamingAssetsPath + $"/Quests/Quest{id}"))
        {
            serializedObject.ApplyModifiedProperties();
            return;
        }

        QuestViewer viewer = serializedObject.targetObject as QuestViewer;

        using (FileStream fs = File.OpenRead(Application.streamingAssetsPath + $"/Quests/Quest{id}"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Quest quest = formatter.Deserialize(fs) as Quest;
            viewer.quest = quest;
        }

        EditorGUILayout.PropertyField(questProperty);
        serializedObject.ApplyModifiedProperties();
    }
}

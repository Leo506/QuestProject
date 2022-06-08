using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Conditions;


[CustomEditor(typeof(QuestCreator))]
public class QuestCreatorEditor : Editor
{
    private int index = 0;

    SerializedProperty conditionProperty;
    SerializedProperty titleProperty;
    SerializedProperty descriptionProperty;
    SerializedProperty idProperty;

    private void OnEnable()
    {
        conditionProperty = serializedObject.FindProperty("condition");
        titleProperty = serializedObject.FindProperty("Title");
        descriptionProperty = serializedObject.FindProperty("Description");
        idProperty = serializedObject.FindProperty("id");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(titleProperty);
        EditorGUILayout.PropertyField(descriptionProperty);
        EditorGUILayout.PropertyField(idProperty);

        string[] options = { (new MailCondition()).GetConditionName() };

        index = EditorGUILayout.Popup(index, options);

        EditorGUILayout.PropertyField(conditionProperty);

    }
}

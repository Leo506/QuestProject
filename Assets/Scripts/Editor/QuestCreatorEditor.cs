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
    SerializedProperty giverIdProperty;
    SerializedProperty stateProperty;

    private void OnEnable()
    {
        conditionProperty = serializedObject.FindProperty("condition");
        titleProperty = serializedObject.FindProperty("Title");
        descriptionProperty = serializedObject.FindProperty("Description");
        idProperty = serializedObject.FindProperty("id");
        giverIdProperty = serializedObject.FindProperty("GiverID");
        stateProperty = serializedObject.FindProperty("State");
    }

    public override void OnInspectorGUI()
    {
        QuestCreator creator = serializedObject.targetObject as QuestCreator;

        EditorGUILayout.PropertyField(titleProperty);

        EditorGUILayout.PropertyField(descriptionProperty);
        EditorGUILayout.PropertyField(idProperty);
        EditorGUILayout.PropertyField(giverIdProperty);
        EditorGUILayout.PropertyField(stateProperty);

        Condition[] conditions = { new MailCondition(), new DestinationCondition() };
        string[] options = { conditions[0].GetConditionName(), conditions[1].GetConditionName() };

        var newIndex = EditorGUILayout.Popup(index, options);

        // TODO изменение отображаемого условия при изменении выбранного типа

        if (newIndex != index)
        {
            index = newIndex;
            creator.condition = conditions[index];
        }


        EditorGUILayout.PropertyField(conditionProperty);
        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Создать квест"))
        {
            creator.CreateQuest();
        }

    }
}

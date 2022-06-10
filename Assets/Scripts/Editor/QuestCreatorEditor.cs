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

    Condition[] conditions;
    string[] options;

    QuestCreator creator;

    private void OnEnable()
    {
        conditionProperty = serializedObject.FindProperty("condition");
        titleProperty = serializedObject.FindProperty("Title");
        descriptionProperty = serializedObject.FindProperty("Description");
        idProperty = serializedObject.FindProperty("id");
        giverIdProperty = serializedObject.FindProperty("GiverID");
        stateProperty = serializedObject.FindProperty("State");

        conditions = ConditionFactory.GetAllConditiions();
        options = ConditionFactory.GetAllConditionsNames();

        creator = serializedObject.targetObject as QuestCreator;

        creator.condition = conditions[index];
    }

    public override void OnInspectorGUI()
    {

        EditorGUILayout.PropertyField(titleProperty);

        EditorGUILayout.PropertyField(descriptionProperty);
        EditorGUILayout.PropertyField(idProperty);
        EditorGUILayout.PropertyField(giverIdProperty);
        EditorGUILayout.PropertyField(stateProperty);

        var newIndex = EditorGUILayout.Popup(index, options);


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

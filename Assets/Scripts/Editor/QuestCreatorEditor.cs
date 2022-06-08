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
        QuestCreator creator = serializedObject.targetObject as QuestCreator;

        EditorGUILayout.PropertyField(titleProperty);

        EditorGUILayout.DelayedTextField(creator.Description);
        EditorGUILayout.PropertyField(descriptionProperty);
        EditorGUILayout.PropertyField(idProperty);

        string[] options = { (new MailCondition()).GetConditionName() };

        var newIndex = EditorGUILayout.Popup(index, options);

        // TODO изменение отображаемого условия при изменении выбранного типа

        /*if (newIndex != index)
        {

            //QuestCreator creator = serializedObject.targetObject as QuestCreator;
            //creator.condition = new MailCondition();
            conditionProperty.managedReferenceValue = new MailCondition();
            index = newIndex;
            Debug.Log("Change to new");
        }*/


        EditorGUILayout.PropertyField(conditionProperty);
        serializedObject.ApplyModifiedProperties();

    }
}

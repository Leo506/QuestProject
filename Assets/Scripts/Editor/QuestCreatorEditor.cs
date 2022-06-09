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

        string[] options = { (new MailCondition()).GetConditionName() };

        var newIndex = EditorGUILayout.Popup(index, options);

        // TODO ��������� ������������� ������� ��� ��������� ���������� ����

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

        if (GUILayout.Button("������� �����"))
        {
            creator.CreateQuest();
        }

    }
}

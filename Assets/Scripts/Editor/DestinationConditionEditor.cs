using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Conditions;

[CustomPropertyDrawer(typeof(DestinationCondition))]
public class DestinationConditionEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);


        var posProperty = property.FindPropertyRelative("triggerPosition");

        label.text = "Позиция триггера";
        EditorGUI.PropertyField(position, posProperty, label);

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * 4;
    }
}

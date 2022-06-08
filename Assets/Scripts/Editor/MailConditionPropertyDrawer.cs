using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Conditions;

[CustomPropertyDrawer(typeof(MailCondition), true)]
public class MailConditionPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var mailTarget = property.FindPropertyRelative("target");
        var subject = property.FindPropertyRelative("subject");

        label.text = "Target";
        position.height = 20;
        EditorGUI.PropertyField(position, mailTarget, label);

        position.y += 40f;
        label.text = "Subject";
        EditorGUI.PropertyField(position, subject, label);

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * 3;
    }
}
